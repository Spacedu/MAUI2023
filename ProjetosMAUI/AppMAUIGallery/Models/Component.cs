using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Models
{
    public class Component
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Type Page { get; set; }
        public bool IsReplaceMainPage { get; set; } = false;
    }
}
