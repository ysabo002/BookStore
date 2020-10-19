using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class SaveForLaterViewModel : BaseEntityViewModel
    {
        public int SaveForLaterID { get; set; }
        public List<BookViewModel> BookList { get; set; }
        public int BuyerID { get; set; }

        public DateTime Date { get; set; }

      


        // Navigation Properties
        public BuyerViewModel Buyer { get; set; } //nav prop
    }
}
