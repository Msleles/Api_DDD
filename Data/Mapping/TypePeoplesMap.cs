using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class TypePeoplesMap : IEntityTypeConfiguration<TypePeople>
    {
 
        public void Configure(EntityTypeBuilder<TypePeople> builder)
        {
            builder.ToTable("TypePeoples");
            builder.Property("Name").IsRequired();
            builder.HasKey(t => t.Id);
        }
    }
}
