
namespace prjFin052701.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using prjFin052701.Controllers;


    public partial class TableBooks1091711
    {
        [DisplayName("書籍IBSN")]
        [Required(ErrorMessage = "IBSN不可為空白")]
        [StringLength(13, ErrorMessage = "IBSN碼必為13個字元")]
        public string BOOK_IBSN { get; set; }
        [DisplayName("書名")]
        [Required(ErrorMessage = "書名不可為空白")] 
        public string BOOK_TITLE { get; set; }
        [DisplayName("作者")] 
        public string BOOK_ATOR { get; set; }
        [DisplayName("書籍分類")]
        [Required(ErrorMessage = "必選書籍分類")] 
        public int CLASS_ID { get; set; }
        [DisplayName("書籍出版日期")]
        [DataType(DataType.Date)] 
        public Nullable<System.DateTime> BOOK_PUB { get; set; }
        [DisplayName("上架日期")]
        [DataType(DataType.Date)] 
        public Nullable<System.DateTime> BOOK_UPDATE { get; set; }
    
        public virtual TableClasss1091711 TableClasss1091711 { get; set; }
    }
}
