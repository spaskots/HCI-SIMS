using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class MedCard
    {
        public int Id { get; set; }
        private List<Anamnesis> anamnesiss = new List<Anamnesis>() ;
        public Patient patient { get; set; }
        private List<Recipe> recipes = new List<Recipe>();
       

       public MedCard()
        {

        }
        public MedCard(int id,Patient patient)
        {
            this.Id = id;
            this.patient = patient;
        }
        public MedCard(int id)
        {
            this.Id = id;
           
        }
        public void setAnamnesis(List<Anamnesis> anamneses)
        {
            this.anamnesiss = anamneses;
        }
       public MedCard(int id,Patient patient,List<Anamnesis> anamneses,List<Recipe> recipes)
        {
            this.Id = id;
            this.patient = patient;
            this.anamnesiss = anamneses;
            this.recipes = recipes;
        }
       
        
    }
}
