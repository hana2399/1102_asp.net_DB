
namespace prjFin052701.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using prjFin052701.Controllers;


    public partial class TablePageds1091711
    {
        [DisplayName("書籍IBSN")]
        [Required(ErrorMessage = "IBSN不可為空白")]
        [StringLength(13, ErrorMessage = "IBSN碼必為13個字元")]
        public string 書籍IBSN碼 { get; set; }
        [DisplayName("書名")]
        [Required(ErrorMessage = "書名不可為空白")]
        public string 書名 { get; set; }
        [DisplayName("作者")] 
        public string 作者 { get; set; }
        [DisplayName("書籍分類")]
        [Required(ErrorMessage = "必選書籍分類")]
        public string 書籍分類 { get; set; }
        [DisplayName("出版日期")]
        [DataType(DataType.Date)] 
        public Nullable<System.DateTime> 出版日期 { get; set; }
        [DisplayName("上架日期")]
        [DataType(DataType.Date)] 
        public Nullable<System.DateTime> 上架日期 { get; set; }
    }
}
