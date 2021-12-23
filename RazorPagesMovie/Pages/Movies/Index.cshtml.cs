using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
//using RazorPagesMovie.Invoices;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        // Razor 頁面衍生自 PageModel。
        // 依照慣例， PageModel 衍生的類別會命名為 <PageName>Model 。 此函式會使用相依性 插入 將加入 RazorPagesMovieContext 至頁面：
        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;

            // ADO.NET
        }

        public IList<ElectronicInvoice> ElectronicInvoice { get;set; }
        
        // 當對頁面提出要求時，方法會將 OnGetAsync 電影清單傳回 Razor 頁面。
        // 在 Razor 頁面上， OnGetAsync 或 OnGet 被呼叫來初始化頁面的狀態。
        // 在此情況下，OnGetAsync 會取得電影清單並加以顯示。
        public async Task OnGetAsync()
        {
            ElectronicInvoice = await _context.ElectronicInvoice.ToListAsync();
        }
    }
}
