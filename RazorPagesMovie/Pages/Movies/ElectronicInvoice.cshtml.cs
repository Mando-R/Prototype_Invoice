using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class ElectronicInvoiceModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        public ElectronicInvoiceModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        // OnGet ��k�|��l�ƭ����һݪ����󪬺A�C �إ߭����S������n��l�ƪ����A�A�ҥH�Ǧ^ Page�C �y��b���оǽҵ{���A�|��� OnGet ��l�ƪ��A���d�ҡC Page ��k�|�إ� PageResult ����A�ΥH�e�{ ElectronicInvoice.cshtml �����C
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ElectronicInvoice ElectronicInvoice { get; set; }

        // ��Ǧ^���O�O IActionResult �� Task<IActionResult> �ɡA�������ѶǦ^���z���C
        // �Ҧp�APages/Movies/Create.cshtml.cs OnPostAsync ��k�G
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ElectronicInvoice.Add(ElectronicInvoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
