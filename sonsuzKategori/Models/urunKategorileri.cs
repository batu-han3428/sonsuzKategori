using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sonsuzKategori.Models
{
    public class urunKategorileri
    {
        [Key]
        public int urunKategorileriId { get; set; }
        [Required]
        public string urunKategorileriKategoriAdi { get; set; }
        public int urunKategorileriUstId { get; set; }
    }
}
