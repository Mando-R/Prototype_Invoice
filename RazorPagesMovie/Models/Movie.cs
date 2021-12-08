using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        // ID 欄位是資料庫對於主索引鍵的必要欄位。
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        // 在屬性中指定資料類型的 [DataType] 屬性 ReleaseDate。使用此屬性：
        // 1. 使用者不需在日期欄位中輸入時間資訊。
        // 2. 只顯示日期，不會顯示時間資訊。
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
