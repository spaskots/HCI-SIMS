using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    

    public class City
    {
        public String Name { get; set; }
        public String PostalCode { get; set; }

        public Country country;

        /// <pdGenerated>default parent getter</pdGenerated>
        public Country GetCountry()
        {
            
            return country;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newCountry</param>
        public void SetCountry(Country newCountry)
        {
            if (this.country != newCountry)
            {
                if (this.country != null)
                {
                    Country oldCountry = this.country;
                    this.country = null;
                    oldCountry.RemoveCity(this);
                }
                if (newCountry != null)
                {
                    this.country = newCountry;
                    this.country.AddCity(this);
                }
            }
        }

        public City(string name, string postalCode, Country country)
        {
            Name = name;
            PostalCode = postalCode;
            this.country = country;
        }
        public City(string name,string postalCode)
        {
            Name = name;
            PostalCode=postalCode;
        }

    }
}
