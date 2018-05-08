using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bliss.Recruitment.Data.Context.Mappings
{
    public class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping()
        {
            ToTable("Question");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName(@"Id")
                .HasColumnType("bigint");

            Property(x => x.QuestionDescription)
                .HasColumnName(@"QuestionDescription")
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(256);

            Property(x => x.ImageUrl)
                .HasColumnName(@"ImageUrl")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(256);

            Property(x => x.ThumbUrl)
                .HasColumnName(@"ThumbUrl")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(256);

            Property(x => x.PublishedAt)
                .HasColumnName(@"PublishedAt")
                .HasColumnType("datetime2")
                .IsRequired();
        }
    }
}
