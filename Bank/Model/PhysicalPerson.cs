namespace Bank.Model
{
    public class PhysicalPerson : Account
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? CPF { get; private set; }
        public DateTime Birth { get; private set; }
    }
}
