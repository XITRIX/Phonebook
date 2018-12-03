namespace Phonebook.API.Models
{
    public partial class User
    {
        public class LocationModel
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
        }
    }
}
