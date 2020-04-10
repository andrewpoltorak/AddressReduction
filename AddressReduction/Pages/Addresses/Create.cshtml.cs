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
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
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
            if (!string.IsNullOrEmpty(Address.LongAddress))
            {
                var textValid = CreateShortURL(Address.LongAddress);
                if (!textValid.Item2)
                {
                    Message = textValid.Item1;
                    return Page();
                }
                else
                {
                    //string[] substring = Address.LongAddress.Split(new string[] { "//" }, StringSplitOptions.None);
                    //Address.LongAddress = substring[1];
                    Address.ShortAddress = textValid.Item1;
                    _context.Address.Add(Address);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }                
            }
            else
            {
                Message = @"Field ""LongAddress"" is empty";
                return Page();
            }
        }

        private Tuple<string, bool> CreateShortURL(string longURL)
        {
            bool valid = false;
            string shortURL = "";
            if (!longURL.StartsWith("http"))
            {
                var textValid = Tuple.Create("Invalid URL format", valid);
                return textValid;
            }
            else
            {
                valid = true;
                Random random = new Random();
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                shortURL = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
                var textValid = Tuple.Create(shortURL, valid);
                return textValid;
            }
        }
    }
}