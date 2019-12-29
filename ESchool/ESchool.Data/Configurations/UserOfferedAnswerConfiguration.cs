using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Data.Configurations
{
    public class UserOfferedAnswerConfiguration : IEntityTypeConfiguration<UserOfferedAnswer>
    {
        public void Configure(EntityTypeBuilder<UserOfferedAnswer> builder)
        {
            builder.HasKey(x => new {x.UserAnswerId, x.OfferedAnswerId});

            builder.HasOne(x => x.UserAnswer)
                .WithMany(x => x.SelectedAnswers)
                .HasForeignKey(x => x.UserAnswerId);

            builder.HasOne(x => x.OfferedAnswer)
                .WithMany(x => x.SelectedAnswers)
                .HasForeignKey(x => x.OfferedAnswerId);
        }
    }
}
