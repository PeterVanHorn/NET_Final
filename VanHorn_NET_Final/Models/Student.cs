namespace VanHorn_NET_Final.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public virtual List<Quiz> Quizzes { get; set; }
        public Teacher Teacher { get; set; }
    }
}
