using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedDate(this ModelBuilder Builder)
        {
            // Seed data for your entities here
            // Example:
            Builder.Entity<User>().HasData(
                 new User { Id = Guid.Parse("12345678-1234-1234-1234-123456789012"), Name = "User Default", Email = "user.default@example.com" }
            );
            return Builder;
        }
    }
}
