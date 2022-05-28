using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
   

    public class User 
    { 

        public String Name { get; set; }
       
        public String Surname { get; set; }
        
        public String? DateOfBirth { get; set; }
        
        public String? PhoneNumber { get; set; }
       
        public String? Email { get; set; }
        
        public String Id { get; set; }  // ID == JMBG
        public Boolean? Active { get; set; }
        
        public String? Username { get; set; }
       
        public String? Password { get; set; }
       
        public City? city { get; set; }

        public User(string name, string surname, String dateOfBirth, string phoneNumber, string email, string id, bool active, string username, string password, City city)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Id = id;
            Active = active;
            Username = username;
            Password = password;
            this.city = city;
        }

        public User(string name, string surname, String dateOfBirth, string phoneNumber, string email, string id)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Id = id;
        }

        public User(string name, string surname, String dateOfBirth, string phoneNumber, string email, string id, City city)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Id = id;
            this.city = city;
        }

        public User(string name, string surname, string dateOfBirth, string phoneNumber, string email, string id, bool v, string username, string password)
        {
            Name=name;
            Surname=surname;
            DateOfBirth=dateOfBirth;
            PhoneNumber=phoneNumber;
            Email=email;
            Id=id;
            Active = v;
            Username = username;
            Password=password;
        }



        // guest account
        public User(string name, string surname, string id)
        {
            Name = name;
            Surname = surname;
            Id = id;
        }

        public User() { }

    }
}
