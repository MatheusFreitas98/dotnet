namespace Dapper.Model {
    public class Career {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public IList<CareerItem>? CareerItems { get; set; }
    }
}