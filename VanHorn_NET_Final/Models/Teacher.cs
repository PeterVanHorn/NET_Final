namespace VanHorn_NET_Final.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public virtual List<Quiz> Quizzes { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
