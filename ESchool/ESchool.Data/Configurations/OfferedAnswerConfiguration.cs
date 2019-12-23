using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Data.Configurations
{
    class OfferedAnswerConfiguration : IEntityTypeConfiguration<OfferedAnswer>
    {
        public void Configure(EntityTypeBuilder<OfferedAnswer> builder)
        {
        }
    }
}
