using GTBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Repository.Configurations
{
    internal class CustomerCafeRelation : IEntityTypeConfiguration<CustomerFavoriteCafeRelation>
    {
       

        public void Configure(EntityTypeBuilder<CustomerFavoriteCafeRelation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(a => a.Customer).WithMany(a => a.CustomerFavoriteCafeRelations).HasForeignKey(a => a.CustomerId);
            builder.HasOne(a => a.Cafe).WithMany(a => a.CustomerFavoriteCafeRelations).HasForeignKey(a => a.CafeId);


          
        }
    }
}
