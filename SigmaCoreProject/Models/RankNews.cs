using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCoreProject.Models
{
    public class RankNews
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int idPhysPers { get; set; }
        public decimal? Rank { get; set; }
    }
}
