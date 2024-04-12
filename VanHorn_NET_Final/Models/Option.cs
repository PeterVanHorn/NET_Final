namespace VanHorn_NET_Final.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool Correct { get; set; }
        public virtual Question Question { get; set; }
    }
}
