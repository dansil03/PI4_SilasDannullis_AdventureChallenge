using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Security.Principal;

namespace AdventureChallenge.Models
{
    public class UserChallenge
    {
        [Key]
        public int UserChallengeId { get; set; }
        public string? ProofText { get; set; }
        [Required]
        public int ChallengeId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public string? ImgUrl { get; set; }

        [NotMapped] //file wordt niet direct in de db opgeslagen maar in de wwwroot/ProofImages folder. 
        public IFormFile? ProofImage { get; set; }
        public Challenge Challenge { get; set; }
        public User User { get; set; }
    }
}
