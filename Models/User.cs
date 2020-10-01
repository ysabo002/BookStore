using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace BookStore.Models
{
    public class User : BaseEntity
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  //TODO encryption
    }
}