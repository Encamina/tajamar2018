using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Encamina.workshop.Backend.Models
{
 
    public class Speaker : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        public string Twitter { get; set; }
        public string Mail { get; set; }
        public string Photo { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
