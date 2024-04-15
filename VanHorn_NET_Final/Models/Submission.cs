namespace VanHorn_NET_Final.Models
{
    public class Submission
    {
        public int SubId { get; set; }
        public virtual List<String> Answers { get; set; }
        public virtual Student Student { get; set; }
        public int? StudentId { get; set; }
    }
}
