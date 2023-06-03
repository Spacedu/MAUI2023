using AppShoppingCenter.Models;
using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppShoppingCenter.Libraries.Storages
{
    public class TicketPreferenceStorage
    {
        private readonly string key = "tickets";
        public void Save(Ticket ticket)
        {
            List<Ticket> tickets;

            if (Preferences.Default.ContainsKey(key))
            {
                var ticketsStr = Preferences.Default.Get<string>(key, default);
                tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsStr);
            } else {
                tickets = new List<Ticket>();
            }

            tickets.Add(ticket);

            Preferences.Default.Clear();
            Preferences.Default.Set(key, JsonSerializer.Serialize(tickets));
        }
        public List<Ticket> Load()
        {
            if (Preferences.Default.ContainsKey(key))
            {
                var ticketsStr = Preferences.Default.Get<string>(key, default);
                var tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsStr);

                return tickets;
            }

            return new List<Ticket>();
        }
    }
}
