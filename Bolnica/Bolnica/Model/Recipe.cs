using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Recipe
    {
        public int id;
        public String medicine;
        public Double quantity;
        public String instruction;
        public Double howOften;
        public String startTime;

        public Patient patient;
        public Recipe(int id, String medicine, Double quantity, String instruction, Double howOften, String startTime)
        {
            this.id = id;
            this.medicine = medicine;
            this.quantity = quantity;
            this.instruction = instruction;
            this.howOften = howOften;
            this.startTime = startTime;
        }


        public MedicalCard medicalCard;

        
    }
}
