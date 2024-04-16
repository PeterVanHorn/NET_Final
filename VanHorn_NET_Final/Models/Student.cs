namespace VanHorn_NET_Final.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public virtual List<Submission> Submissions { get; set; }
        public Teacher Teacher { get; set; }
        public int? TeacherId { get; set; }
    }
}
