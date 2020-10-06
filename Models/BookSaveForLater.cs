using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookSaveForLater
    {
        [Key]
        public int BookSaveForLaterID { get; set; }
        public int SaveForLaterID { get; set; }
        public int BookID { get; set; }

        public SaveForLater SaveForLater { get; set; } //nav prop
        public Book Book { get; set; } //nav prop
    }
}
