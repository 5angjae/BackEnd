using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Models
{
    public class Kart
    {
        [Key]
        public int KartIdx { get; set; }
        public float LabTime { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
