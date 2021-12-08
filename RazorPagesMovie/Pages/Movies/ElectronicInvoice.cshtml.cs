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
        // OnGet 方法會初始化頁面所需的任何狀態。 建立頁面沒有任何要初始化的狀態，所以傳回 Page。 稍後在此教學課程中，會顯示 OnGet 初始化狀態的範例。 Page 方法會建立 PageResult 物件，用以呈現 ElectronicInvoice.cshtml 頁面。
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ElectronicInvoice ElectronicInvoice { get; set; }

        // 當傳回型別是 IActionResult 或 Task<IActionResult> 時，必須提供傳回陳述式。
        // 例如，Pages/Movies/Create.cshtml.cs OnPostAsync 方法：
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
