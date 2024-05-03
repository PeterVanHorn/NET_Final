//Peter Van Horn
//.NET Final Project
//05/03/2024
//Student class can take quizzes but not view details or other students quiz results

namespace VanHorn_NET_Final.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Submission> Submissions { get; set; }
        public Teacher Teacher { get; set; }
        public int? TeacherId { get; set; }
    }
}
