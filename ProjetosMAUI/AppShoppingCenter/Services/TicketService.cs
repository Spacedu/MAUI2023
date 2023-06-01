using AppShoppingCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Services
{
    public class TicketService
    {
        public Ticket GetTicket(string ticketNumber)
        {
            return MockTicketService.GetTicket(ticketNumber);
        }

        public List<Ticket> GetTickets()
        {
            return MockTicketService.GetTickets();
        }
    }

    public class MockTicketService
    {
        private static List<Ticket> tickets = new List<Ticket>() {
            new Ticket()
            {
                Id = 1,
                TicketNumber = "209883557324",
                DataIn = new DateTimeOffset(2023, 06, 01, 12, 00, 00, TimeSpan.FromHours(-3)),
            },
            new Ticket()
            {
                Id = 2,
                TicketNumber = "320683687451",
                DataIn = new DateTimeOffset(2023, 06, 01, 15, 00, 00, TimeSpan.FromHours(-3)),
            }
        };
        public static Ticket GetTicket(string ticketNumber)
        {
            return tickets.FirstOrDefault(a => a.TicketNumber == ticketNumber.Replace(" ", string.Empty));
        }
        public static List<Ticket> GetTickets()
        {
            //TODO - Pegar os tickets armazenados no dispositivo.
            return null;
        }
    }
}
