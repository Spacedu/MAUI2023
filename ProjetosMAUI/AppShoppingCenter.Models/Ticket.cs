using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; } = null!;
        public DateTimeOffset DataIn { get; set; }
        public DateTimeOffset DataOut { get; set; } //Date - Pay
        public DateTimeOffset DataTolerance { get; set; }
        public double Price { get; set; }
    }
}
