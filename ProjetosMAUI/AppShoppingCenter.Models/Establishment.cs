using AppShoppingCenter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Models
{
    public class Establishment
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Localization { get; set; } = null!;
        public string? Phone { get; set; }
        public EstablishmentType Type { get; set; }

        public string Cover { get; set; } = null!;
        public string Logo { get; set; } = null!;
    }

}
