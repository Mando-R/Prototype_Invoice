using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ElectronicInvoice ElectronicInvoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ElectronicInvoice = await _context.ElectronicInvoice.FirstOrDefaultAsync(m => m.ID == id);

            if (ElectronicInvoice == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ElectronicInvoice = await _context.ElectronicInvoice.FindAsync(id);

            if (ElectronicInvoice != null)
            {
                _context.ElectronicInvoice.Remove(ElectronicInvoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
