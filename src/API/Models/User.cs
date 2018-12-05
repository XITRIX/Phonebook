namespace Phonebook.API.Models
{
    public class User
    {
        public UserNameModel Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public PictureModel Picture { get; set; }
    }
}
