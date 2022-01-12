using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
//using RazorPagesMovie.Invoices;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    // 1. 建立客製資料結構 class
    public class RyanViewModel
    {
        public string Category { get; set; }
        public string Id { get; set; }
    }

    // 建立客製資料結構 class
    public class InvoiceBindCategory
    {
        public InvoiceBindCategory()
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
        }
        // 1. ElectronicInvoiceID
        public int ID { get; set; }

        // 2. ExpenseOrRevenue 支出/收入
        public string InvoicePurpose { get; set; }

        // public InvoicePurposeList InvoicePurpose { get; set; }
        public enum InvoicePurposeList
        {
            [Display(Name = "支出")]
            Expense = 0,

            [Display(Name = "收入")]
            Revenue = 1
        }

        // 3. 發票日期
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        // 4. 發票金額
        [Column(TypeName = "decimal(18,4)")]
        public decimal InvoiceAmount { get; set; }

        // 5. CreatedOn
        public DateTimeOffset CreatedOn { get; set; }

        // 6. LatestUpdatedOn
        public DateTimeOffset LatestUpdatedOn { get; set; }

        // 7. CategoryID
        // Relation：ElectronicInvoice[M] -> [1]InvoiceCategory
        public int InvoiceCategoryID { get; set; }

        [ForeignKey("InvoiceCategoryID")]
        public InvoiceCategory InvoiceCategory { get; set; }

        // 8. CompanyID
        // Relation：ElectronicInvoice[M] -> [1]Company
        public int CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public Company Company { get; set; }

        public string Category { get; set; }
    }

    public class IndexModel : PageModel
    {
        // 2. 以<資料結構>，定義 List 結構
        public List<RyanViewModel> Records { get; set; }
        public List<InvoiceBindCategory> InvoiceBindCategory { get; set; }

        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        // Razor 頁面衍生自 PageModel。
        // 依照慣例， PageModel 衍生的類別會命名為 <PageName>Model 。 此函式會使用相依性 插入 將加入 RazorPagesMovieContext 至頁面：
        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;

            // SqlConnection：串接資料庫連線字串。
            string connectionString = "Data Source=DESKTOP-3A4G34R\\SQLEXPRESS02;Initial Catalog=RazorPagesMovie.dev01;User ID=sa;Password=52678143QAZWSX!@#$%^;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cn = new SqlConnection(connectionString);

            // SqlConnection.Open：開啟資料庫連接。
            cn.Open();

            // SqlCommand：準備 SQL 指令。
            //SqlCommand cmd = new SqlCommand(@"SELECT TOP (1000) [ID]
            //                                  ,[Category]
            //                                  FROM [RazorPagesMovie.dev01].[dbo].[InvoiceCategory]", cn);
            SqlCommand cmd = new SqlCommand(@"SELECT [ElectronicInvoice].[ID]
                                                    ,[InvoicePurpose]
                                                    ,[InvoiceDate]
                                                    ,[InvoiceAmount]
                                                    ,[CreatedOn]
                                                    ,[LatestUpdatedOn]
                                                    ,[InvoiceCategoryID]
                                                    ,[CompanyID]
                                                    ,[InvoiceCategory].Category
                                                FROM [RazorPagesMovie.dev01].[dbo].[ElectronicInvoice]
                                                JOIN [RazorPagesMovie.dev01].[dbo].[InvoiceCategory]
                                                  ON [ElectronicInvoice].InvoiceCategoryID = [InvoiceCategory].ID", cn);

            // SqlDataReader：ADO.NET 取資料。cmd.ExecuteReader()：對資料庫執行 SQL 指令＋撈資料。
            SqlDataReader dr = cmd.ExecuteReader();

            // 3. new List
            List<RyanViewModel> list = new List<RyanViewModel>();
            List<InvoiceBindCategory> list2 = new List<InvoiceBindCategory>();

            // 4. while迴圈，Read() 讀取資料 dr。
            while (dr.Read())  // 嘗試讀取一筆資料列，並回傳是否成功。
            {
                // 範例
                //listBoxl.Items.Add(dr["ProductName"].ToString());
                // 5. new 資料結構
                RyanViewModel ryanViewModel = new RyanViewModel();
                ryanViewModel.Category = dr["Category"].ToString();
                ryanViewModel.Id = dr["Id"].ToString();

                InvoiceBindCategory invoiceBindCategory = new InvoiceBindCategory();
                invoiceBindCategory.CompanyID = (int)dr["CompanyID"];
                invoiceBindCategory.InvoicePurpose = dr["InvoicePurpose"].ToString();
                invoiceBindCategory.InvoiceCategoryID = (int)dr["InvoiceCategoryID"];
                invoiceBindCategory.InvoiceDate = (DateTime)dr["InvoiceDate"];
                invoiceBindCategory.InvoiceAmount = (decimal)dr["InvoiceAmount"];
                invoiceBindCategory.CreatedOn = (DateTimeOffset)dr["CreatedOn"];
                invoiceBindCategory.LatestUpdatedOn = (DateTimeOffset)dr["LatestUpdatedOn"];
                invoiceBindCategory.InvoiceCategoryID = (int)dr["InvoiceCategoryID"];
                invoiceBindCategory.Category = dr["Category"].ToString();

                // 6. 裝載
                list.Add(ryanViewModel);
                list2.Add(invoiceBindCategory);

                //Console.WriteLine($"list:\n {list}");
                //Console.WriteLine($"ryanViewModel:\n {ryanViewModel}");
                //Console.WriteLine("dr:" + dr.ToString());
                //Console.WriteLine("dr[0]:" + dr[0].ToString());
                //Console.WriteLine("dr[1]:" + dr[1].ToString());
                //Console.WriteLine("dr[2]:" + dr[2].ToString());
                //Console.WriteLine("Category:" + dr["Category"].ToString());
                //Console.WriteLine("dr[@ID@].ToString():" + dr["ID"].ToString());
                //Console.WriteLine($"dr:\n {dr}");
                //Console.WriteLine(dr["Category"].ToString());
            }

            int countNumber = list.Count();

            // 關閉＆釋放記憶體
            cn.Close();
            cn.Dispose();

            // 7. list 放入 Records
            Records = list;
            // 對應 View 的 @{ foreach (InvoiceBindCategory renderList in Model.InvoiceBindCategory)
            InvoiceBindCategory = list2;

        }

        public IList<ElectronicInvoice> ElectronicInvoice { get; set; }

        // 當對頁面提出要求時，方法會將 OnGetAsync 電影清單傳回 Razor 頁面。
        // 在 Razor 頁面上， OnGetAsync 或 OnGet 被呼叫來初始化頁面的狀態。
        // 在此情況下，OnGetAsync 會取得電影清單並加以顯示。
        public async Task OnGetAsync()
        {
            Console.WriteLine("Testing");
            ElectronicInvoice = await _context.ElectronicInvoice.ToListAsync();
        }
    }
}
