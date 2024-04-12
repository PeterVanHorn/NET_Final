namespace VanHorn_NET_Final.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int? TeacherId { get; set; }
        //public virtual Student Student { get; set; }
        //public int? StudentId { get; set; }
    }
}
