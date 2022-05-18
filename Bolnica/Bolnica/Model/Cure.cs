using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Cure
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public Boolean VerificationState { get; set; }

        public Cure() { }
        public Cure(int Id, String Name, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = Quantity;
            this.VerificationState = false; // Nije verifikovan nakon kreiranja
        }
        public Cure(int Id, String Name, int Quantity, Boolean verificationState)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = Quantity;
            this.VerificationState = verificationState; // Nije verifikovan nakon kreiranja
        }
    }
}
