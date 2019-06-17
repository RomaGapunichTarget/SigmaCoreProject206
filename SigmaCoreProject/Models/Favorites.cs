using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCoreProject.Models
{
    public class Favorites
    {
        public int Id { get; set; }
        public int IdNews { get; set; }
        public int IdPers { get; set; }
        public string IdUser { get; set; }
    }
}
