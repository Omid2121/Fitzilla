using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Repositories
{
    public class SessionRepositoryTests(ITestOutputHelper testOutputHelper) : WebApiApplication(testOutputHelper)
    {
    }
}
