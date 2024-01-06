namespace Bank.Model
{
    public abstract class Account
    {
        public int Number { get; private set; }
        public double Balance { get; private set; }
    }
}
