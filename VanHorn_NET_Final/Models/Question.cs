namespace VanHorn_NET_Final.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public virtual List<String> Options { get; set; }
        public string Answer { get; set; }
    }
}
