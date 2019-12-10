using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(x => x.OfferedAnswer)
                .WithOne(x => x.Question)
                .HasForeignKey<OfferedAnswer>(x => x.QuestionId);
        }
    }
}
