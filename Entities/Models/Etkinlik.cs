using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Etkinlik
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Yer { get; set; }
        public DateTime Zaman { get; set; }
        public bool UcretliUcretsiz { get; set; }
        public decimal Ucret { get; set; }
        public string Aciklama { get; set; }
        public string Gorsel { get; set; }
    }
}
