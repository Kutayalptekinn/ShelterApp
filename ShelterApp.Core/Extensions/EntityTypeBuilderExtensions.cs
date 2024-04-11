using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShelterApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Core.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureByConvention(this EntityTypeBuilder b)
        {
            b.TryConfigureEntityId();
        }

        public static void TryConfigureEntityId(this EntityTypeBuilder b)
        {

            b.Property(nameof(IEntity.ID))
                .IsRequired()
                .HasColumnName(nameof(IEntity.ID));

        }
    }
}
