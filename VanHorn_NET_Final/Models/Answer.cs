//Peter Van Horn
//.NET Final Project
//05/03/2024

namespace VanHorn_NET_Final.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool Correct { get; set; }
        public Submission Submission { get; set; }
        public int? SubmissionId { get; set; }
    }
}
