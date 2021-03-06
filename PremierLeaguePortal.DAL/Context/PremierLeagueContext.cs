﻿using Microsoft.AspNet.Identity.EntityFramework;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.DAL.Context
{
    public class PremierLeagueContext : IdentityDbContext<ApplicationUser>
    {
        ////The name of the connection string is passed to the constructor
        public PremierLeagueContext() : base("PremierLeagueContext")
        {

        }
        /// <summary>
        /// DbSet represents the blog table in the database
        /// </summary>
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<PoolItem> PoolItems { get; set; }

        //public DbSet<Team> Teams { get; set; }
        //public DbSet<Player> Players { get; set; }
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<TeamOfTheWeek> TeamOfTheWeek { get; set; }
        //public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove the pluralizing convention, so I will handle table names myself
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Properties<DateTime?>()
                .Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

        public static PremierLeagueContext Create()
        {
            return new PremierLeagueContext();
        }

    }
}