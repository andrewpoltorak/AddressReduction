using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddressReduction.Data;
using AddressReduction.Models;
using System.Text;

namespace AddressReduction.Pages.Addresses
{
    public class CreateModel : PageModel
    {
        private readonly AddressReduction.Data.AddressReductionContext _context;
        [BindProperty]
        public Address Address { get; set; }

        public CreateModel(AddressReduction.Data.AddressReductionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var shortURL = CreateShortURL();
            Address.ShortAddress = shortURL;
            _context.Address.Add(Address);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private string CreateShortURL()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string shortURL = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return shortURL;
        }
    }
}