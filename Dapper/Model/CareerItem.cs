namespace Dapper.Model
{
    public class CareerItem 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Course? Course { get; set; }
    }    
}