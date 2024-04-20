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
