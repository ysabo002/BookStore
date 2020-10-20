﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class AddressViewModel : BaseEntityViewModel
    {
        
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Type { get; set; }   //type can be main address or shipping address

        public int BuyerID { get; set; }

        public BuyerViewModel Buyer { get; set; } //nav prop
    }
}