namespace Web.Models.Entity
{
    public class Subscribes
    {
        public int Id { get; set; }
        public User Who { get; set; }
        public User To { get; set; }
    }
}