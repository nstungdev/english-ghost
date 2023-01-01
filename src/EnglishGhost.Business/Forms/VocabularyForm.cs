using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishGhost.Business.Forms
{
    public class VocabularyForm
    {
        public string Word { get; set; } = "n/a";
        public string Type { get; set; } = "n/a";
        public string Mean { get; set; } = "n/a";
        public string? Pronounce { get; set; }
        public string? Note { get; set; }
    }
}
