using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Tests.Integration.Repositories
{
    public class ExerciseTemplateRepositoryTests : GenericRepositoryTests<ExerciseTemplate>
    {
        protected override GenericRepository<ExerciseTemplate> Repo => UnitOfWork.ExerciseTemplates;

        protected override ExerciseTemplate CreateModel()
        {
            return new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                Name = "New ExerciseTemplate",
                Description = "Test for new ExerciseTemplate",
                Image = "image.png",
                CreationTime = DateTime.Now,
            };
        }
    }
}
