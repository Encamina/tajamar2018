using System;
using System.Collections.Generic;
using System.Text;

namespace Encamina.workshop.Backend.Models
{
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public DateTime DateEvent { get; set; }
        public string Organizer { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
