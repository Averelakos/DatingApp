﻿using Microsoft.EntityFrameworkCore;
using PassionPortal.Infrastructure.Common.Persistance.Configurations.AuthConfiguration;

namespace PassionPortal.Infrastracture;
public sealed partial class DatingAppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelCreating(modelBuilder);
    }

    public void ModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

