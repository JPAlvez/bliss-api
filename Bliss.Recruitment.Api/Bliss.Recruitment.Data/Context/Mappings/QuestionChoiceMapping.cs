using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace Bliss.Recruitment.Data.Context.Mappings
{
    public class QuestionChoiceMapping : EntityTypeConfiguration<QuestionChoice>
    {
        public QuestionChoiceMapping()
        {
            ToTable("QuestionChoice");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName(@"Id")
                .HasColumnType("bigint");

            Property(x => x.Name)
                .HasColumnName(@"Name")
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(128);

            Property(x => x.Votes)
                .HasColumnName(@"Votes")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.QuestionId)
                .HasColumnName(@"QuestionId")
                .HasColumnType("bigint")
                .IsRequired();

            HasRequired(a => a.Question)
                .WithMany(b => b.QuestionChoices)
                .HasForeignKey(c => c.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}
