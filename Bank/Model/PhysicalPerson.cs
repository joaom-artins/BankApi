using System.ComponentModel.DataAnnotations;

namespace Bank.Model
{
    public class PhysicalPerson : Account
    {
        public int Id { get;  set; }
        public string? Name { get;  set; }
        public string? CPF { get;  set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime Birth { get;  set; }
    }
}
