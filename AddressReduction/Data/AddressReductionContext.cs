using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddressReduction.Models;

namespace AddressReduction.Data
{
    public class AddressReductionContext : DbContext
    {
        public AddressReductionContext (DbContextOptions<AddressReductionContext> options)
            : base(options)
        {
        }

        public DbSet<AddressReduction.Models.Address> Address { get; set; }
    }
}
