namespace StoredProcedure123.Models
{
    public class Tooted
    {
        public int Id { get; set; }
        public string Kategooria { get; set; } = string.Empty;
        public string Nimetus { get; set; } = string.Empty;
        public decimal Hind { get; set; }
        public int Laos { get; set; }
    }
}
