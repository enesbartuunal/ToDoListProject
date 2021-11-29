using MZKWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMAZAKA.Models
{
    public class DutyModel
    {
        public int Id { get; set; }

        public string Başlık { get; set; }

        public string Acıklama { get; set; }

        public DateTime Başlangıc { get; set; }

        public DateTime Bitis { get; set; }

        public bool Tamamlandı { get; set; }

        public  ApplicationUser applicationUser { get; set; }

        public string applicationUserId { get; set; }
                
    }
}