using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Buyer : BaseEntity
    {
        public int BuyerID { get; set; }
        public string Name { get; set; }
        public List<Card> CardList { get; set; }
        public List<Address> AddressList { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public List<BookBuyer> BookBuyers { get; set; } //aux list for relationship many to many
    }
}
