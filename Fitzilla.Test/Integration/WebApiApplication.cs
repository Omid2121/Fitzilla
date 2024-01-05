using Fitzilla.DAL;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration
{
    public class WebApiApplication : WebApplicationFactory<Program>
    {
        //protected readonly HttpClient _client;
        protected UnitOfWork UnitOfWork { get; set; }
        private readonly ITestOutputHelper _testOutputHelper;

        public WebApiApplication(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    service => service.ServiceType == typeof(DbContextOptions<DatabaseContext>));

                services.Remove(descriptor);

                var authenticationDescriptor = services.SingleOrDefault(
                    service => service.ServiceType == typeof(AuthenticationService));

                services.Remove(authenticationDescriptor);

                var authorizationDescriptor = services.SingleOrDefault(
                    service => service.ServiceType == typeof(IAuthorizationService));

                services.Remove(authorizationDescriptor);

                string dbName = "InMemoryDbForTesting" + Guid.NewGuid().ToString();

                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase(dbName);
                });


                // Create a new service provider.
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
                {
                    try
                    {
                        UnitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>() as UnitOfWork ?? throw new NullReferenceException("UnitOfWork is null");
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        _testOutputHelper.WriteLine(ex.Message);
                        throw;
                    }
                }
            });

            return base.CreateHost(builder);
        }

        //protected async Task AuthenticateAsync() 
        //{
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        //}

        ////TODO: Make sure the route is correct
        //private async Task<string> GetJwtAsync()
        //{
        //    var response = await _client.PostAsJsonAsync($"{HttpHelper.Urls.AccountURL}/register", new LoginUserDTO
        //    {
        //        Email = "test@integration.com",
        //        Password = "Password1234!"
        //    });

        //    var registerationResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
        //    return registerationResponse.Token;
        //}
    }
}
