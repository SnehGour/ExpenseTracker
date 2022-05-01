using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
