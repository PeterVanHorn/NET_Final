namespace VanHorn_NET_Final.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public virtual List<Option> Options { get; set; }
    }
}
