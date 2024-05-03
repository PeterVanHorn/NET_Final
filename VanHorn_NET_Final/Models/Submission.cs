//Peter Van Horn
//.NET Final Project
//05/03/2024
//Submissions are the objects created over the course of a student taking a quiz.
//submissions have a list of answers and a student.

using System.ComponentModel.DataAnnotations;

namespace VanHorn_NET_Final.Models
{
    public class Submission
    {
        [Key]
        public int SubId { get; set; }
        public Quiz Quiz { get; set; }
        public int? QuizId { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual Student Student { get; set; }
        public int? StudentId { get; set; }
    }
}
