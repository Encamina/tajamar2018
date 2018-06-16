using System;
using System.Collections.Generic;
using System.Text;

namespace Encamina.workshop.Backend.Models
{
    public class Session : BaseModel
    {
        public string Title { get; set; }
        public int ConferenceId { get; set;}
        public string Description { get; set; }
        public int Level { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
