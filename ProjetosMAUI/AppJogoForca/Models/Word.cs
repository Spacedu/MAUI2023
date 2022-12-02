using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Models
{
    public class Word
    {
        public Word(String tips, String text) { 
            this.Tips = tips;
            this.Text = text;
        }
        public String Tips { get; set; } = string.Empty;
        public String Text { get; set; } = string.Empty;
    }
}
