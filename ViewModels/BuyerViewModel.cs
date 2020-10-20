using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BuyerViewModel : BaseEntityViewModel
    {
        
        public int BuyerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<CardViewModel> CardList { get; set; }
        public List<AddressViewModel> AddressList { get; set; }
        public string Email { get; set; }
        [Required]
        public string Nickname { get; set; }

    }
}
