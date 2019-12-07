using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using ESchool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ESchool.Data
{
    public class ESchoolContext : IdentityDbContext<User>
    {


        public ESchoolContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
