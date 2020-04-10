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
    public class IndexModel : PageModel
    {
        private readonly AddressReduction.Data.AddressReductionContext _context;

        public IndexModel(AddressReduction.Data.AddressReductionContext context)
        {
            _context = context;
        }
        public IList<Address> Address { get; set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Address.ToListAsync();
        }

        public async Task<ActionResult> OnPostClickedAsync(int id)
        {
            Address = _context.Address.ToList();
            string url = "";
            foreach (var address in Address)
            {
                if (address.Id == id)
                {
                    url = address.LongAddress;
                    address.Clicked++;
                    _context.Attach(address).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return Redirect(url);
        }
    }
}
