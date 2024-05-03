//Peter Van Horn
//.NET Final Project
//05/03/2024
//Teacher class can create quizzes and view all submissions and student details.
//teachers can have a list of quizzes and a list of students.

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
