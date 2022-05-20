using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Patient : User
    {
        public Patient(string name, string surname, String dateOfBirth, 
            string phoneNumber, string email, string id, bool active, string username, 
            string password, City city) : base(name, surname, dateOfBirth, phoneNumber, email, id, active, username, password, city)
        {
        }

        public Patient(string name, string surname, String dateOfBirth,
            string phoneNumber, string email, string id) :
            base(name, surname, dateOfBirth, phoneNumber, email, id)
        {
        }

        public Patient(string name, string surname, String dateOfBirth,
            string phoneNumber, string email, string id, City city) :
            base(name, surname, dateOfBirth, phoneNumber, email, id, city)
        {
        }

        public Patient(string name, string surname, string id) : base(name, surname, id) { }

        public Patient() { }

        public Patient(string name, string surname, string dateOfBirth, string phoneNumber, string email, string id, bool v, string username, string password) : base(name, surname, dateOfBirth, phoneNumber, email, id, v, username, password)
        {

        }
    }
}
