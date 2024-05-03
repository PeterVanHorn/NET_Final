//Peter Van Horn
//.NET Final Project
//05/03/2024
//Options represent the possible options for questions, created by the teacher.

namespace VanHorn_NET_Final.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool Correct { get; set; }
        public virtual Question Question { get; set; }
        public int? QuestionId { get; set; }
    }
}
