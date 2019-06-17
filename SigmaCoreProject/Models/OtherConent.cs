using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCoreProject.Models
{
    public class OtherContent
    {
        public int Id { get; set; }
        public string TitleContent { get; set; }
        public string BodyContent { get; set; }

        public string IdUserCreate { get; set; }

        public int IdPhysPer { get; set; }
        public int IdTypeContent { get; set; }

        public bool IsVislbe { get; set; }
    }
}
