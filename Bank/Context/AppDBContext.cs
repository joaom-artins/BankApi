using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Context
{
    public class AppDBContext : DbContext
    {
            public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
            {
            }

        public DbSet<LegalPerson> LegalPersons { get; set;}
        public DbSet<PhysicalPerson> PhysicalPersons { get; set;}


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<LegalPerson>().HasKey(i => i.Id);
            mb.Entity<LegalPerson>().Property(i => i.CorporateReason).HasMaxLength(255).IsRequired();
            mb.Entity<LegalPerson>().Property(i => i.FantasyName).HasMaxLength(255).IsRequired();
            mb.Entity<LegalPerson>().Property(i => i.CNPJ).HasMaxLength(11).IsRequired();
            mb.Entity<LegalPerson>().Property(i => i.Number).HasMaxLength(7).IsRequired();
            mb.Entity<LegalPerson>().Property(i => i.Balance).HasPrecision(18, 2);


            mb.Entity<PhysicalPerson>().HasKey(i => i.Id);
            mb.Entity<PhysicalPerson>().Property(i=>i.Name).HasMaxLength(255).IsRequired();
            mb.Entity<PhysicalPerson>().Property(i => i.CPF).HasMaxLength(11).IsRequired();
            mb.Entity<PhysicalPerson>().Property(i => i.Birth).HasColumnType("datetime");
            mb.Entity<PhysicalPerson>().Property(i=>i.Number).HasMaxLength(7).IsRequired();
            mb.Entity<PhysicalPerson>().Property(i => i.Balance).HasPrecision(18, 2);
        }
    }
}
