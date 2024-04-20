using System.ComponentModel.DataAnnotations;

namespace VanHorn_NET_Final.Models
{
    public class Submission
    {
        [Key]
        public int SubId { get; set; }
        public Quiz Quiz { get; set; }
        public int? QuizId { get; set; }
        public virtual List<Option> Options { get; set; }
        public virtual Student Student { get; set; }
        public int? StudentId { get; set; }
    }
}
