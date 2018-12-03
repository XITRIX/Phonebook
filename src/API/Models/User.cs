namespace Phonebook.API.Models
{
    public partial class User
    {
        public string Gender { get; set; }
        public UserNameModel Name { get; set; }
        public LocationModel Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PictureModel Picture { get; set; }
    }
}
