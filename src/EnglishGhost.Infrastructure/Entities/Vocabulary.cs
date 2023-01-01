using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishGhost.Infrastructure.Entities
{
    public class Vocabulary
    {
        public int Id { get; set; }
        public string Word { get; set; } = "n/a";
        public string Type { get; set; } = "n/a";
        public string Mean { get; set; } = "n/a"; 
        public string? Pronounce { get; set; }
        public string? Note { get; set; }
    }
}
