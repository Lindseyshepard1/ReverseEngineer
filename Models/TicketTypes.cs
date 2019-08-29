using System;
using System.Collections.Generic;

namespace WinterReverse.Models
{
    public partial class TicketTypes
    {
        public TicketTypes()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int TicketTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
