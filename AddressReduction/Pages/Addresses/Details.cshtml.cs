using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressReduction.Data;
using AddressReduction.Models;

namespace AddressReduction.Pages.Addresses
{
    public class DetailsModel : PageModel
    {
        private readonly AddressReduction.Data.AddressReductionContext _context;

        public DetailsModel(AddressReduction.Data.AddressReductionContext context)
        {
            _context = context;
        }

        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);

            if (Address == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
