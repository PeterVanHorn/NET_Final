//Peter Van Horn
//.NET Final Project
//05/03/2024

namespace VanHorn_NET_Final.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Quiz> Quizzes { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
