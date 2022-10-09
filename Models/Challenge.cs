using System.ComponentModel.DataAnnotations;

namespace AdventureChallenge.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ChallengeName { get; set; }
        public string ChallengeDescription { get; set; }
        public int NumberOfPlayers { get; set; }
        public string DayTime { get; set; }
        public virtual ICollection<UserChallenge> User { get; set; }

    }
}

