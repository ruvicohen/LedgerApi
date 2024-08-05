namespace LedgerApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Ladger>? Ledgers { get; set; } = new List<Ladger>();
    }
}
