using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCoreProject.Models
{
    public class ModelReadNews
    {
        public int IdNews { get; set; }
        public string TitileNews { get; set; }

        public string Bodynews { get; set; }

        public string BodyComment { get; set; }

        
        public List<Commnetsnews> lstComentNews {get;set;}
    }

    public class Commnetsnews
    {
        public int idComent { get; set; }
        public string DateCrateCommnet { get; set; }
        public string Comment { get; set; }
    }
}
