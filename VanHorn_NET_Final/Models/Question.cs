//Peter Van Horn
//.NET Final Project
//05/03/2024

namespace VanHorn_NET_Final.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public virtual List<Option> Options { get; set; }
        public virtual Quiz Quiz { get; set; }
        public int? QuizId { get; set; }
    }
}
