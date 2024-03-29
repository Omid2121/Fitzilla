﻿using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Repositories
{
    public class ExerciseTemplateRepositoryTests(ITestOutputHelper testOutputHelper) : GenericRepositoryTests<ExerciseTemplate>(testOutputHelper)
    {
        protected override GenericRepository<ExerciseTemplate> Repository => UnitOfWork.ExerciseTemplates;


        protected override ExerciseTemplate CreateModel()
        {
            return new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                Title = "New ExerciseTemplate",
                Description = "Test for new ExerciseTemplate",
                Image = "image.png",
                CreatedAt = DateTime.Now,
            };
        }
    }
}
