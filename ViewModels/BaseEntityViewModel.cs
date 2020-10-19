using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BaseEntityViewModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
