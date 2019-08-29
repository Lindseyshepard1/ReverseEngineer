using System;
using System.Collections.Generic;

namespace WinterReverse.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int ResortId { get; set; }
        public decimal Price { get; set; }
        public int TicketTypeId { get; set; }

        public virtual TicketTypes TicketType { get; set; }
    }
}
