namespace Bank.Model
{
    public class LegalPerson : Account
    {
        public int Id { get;  set; }
        public string? FantasyName { get;  set; }
        public string? CorporateReason { get; set; }
        public string? CNPJ { get;  set; }
    }
}
