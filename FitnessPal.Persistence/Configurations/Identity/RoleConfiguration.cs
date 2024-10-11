﻿using FitnessPal.Application.Models.Identity;
using FitnessPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = 1,
                    ConcurrencyStamp = new Guid().ToString(),
                },
                new Role
                {
                    Name = "Client",
                    NormalizedName = "CLIENT",
                    Id = 2,
                    ConcurrencyStamp = new Guid().ToString(),
                }
            );
        }
    }
}
