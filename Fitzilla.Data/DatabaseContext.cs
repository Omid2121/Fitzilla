﻿using Fitzilla.DAL.Configurations.Entities;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fitzilla.DAL;

public class DatabaseContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<Media> Medias { get; set; }
    public DbSet<Macro> Macros { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseRecord> ExerciseRecords { get; set; }
    public DbSet<ExerciseTemplate> ExerciseTemplates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new MediaConfiguration());
        builder.ApplyConfiguration(new ExerciseRecordConfiguration());
        builder.ApplyConfiguration(new ExerciseTemplateConfiguration());
        builder.ApplyConfiguration(new ExerciseConfiguration());
        builder.ApplyConfiguration(new SessionConfiguration());
        builder.ApplyConfiguration(new MacroConfiguration());
        builder.ApplyConfiguration(new PlanConfiguration());
        builder.ApplyConfiguration(new RatingConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
    }
}
