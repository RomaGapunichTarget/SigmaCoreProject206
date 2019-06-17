using System;
using System.Collections.Generic;

namespace SigmaCoreProject.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string TitleNews { get; set; }
        public string BodyNews { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateStartVisible { get; set; }
        public DateTime? DateEndVisible { get; set; }
        public bool? IsVisible { get; set; }
        public string IdUserCreate { get; set; }
        public string ShoreInfo { get; set; }
        public string SeoDesc { get; set; }
        public string SeoTitlte { get; set; }
    }
}
