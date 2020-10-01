namespace BookStore.Models
{
    public class Address : BaseEntity
    {
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Preferred { get; set; }
    }
}