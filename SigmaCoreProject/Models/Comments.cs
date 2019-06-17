using System;
using System.Collections.Generic;

namespace SigmaCoreProject.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public DateTime? DateComent { get; set; }
        public string BodyComment { get; set; }
        public int? IdNews { get; set; }
        public int? IdParentComent { get; set; }
    }
}
