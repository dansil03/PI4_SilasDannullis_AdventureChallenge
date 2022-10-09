using System.ComponentModel.DataAnnotations;

namespace AdventureChallenge.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required, StringLength(100)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<UserChallenge> UserChallenges { get; set; }
    }
}
