namespace Bank.Model
{
    public class LegalPerson : Account
    {
        public int Id { get; private set; }
        public string? FantasyName { get; private set; }
        public string? CorporateReason { get; set; }
        public string? CNPJ { get; private set; }
    }
}
