using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class MedicalCard
    {
        public int Id { get; set; }
        //private List<Allergen> allergens = new List<Allergen>();
        private List<Anamnesis> anamnesiss = new List<Anamnesis>();
        Patient patient;
        private List<Recipe> recipes = new List<Recipe>();
        //private List<MedicalInstruction> medicalInstructions = new List<MedicalInstruction>();

       
        //private AllergenRepository allergenRepository = new AllergenRepository();
        //private AnamnesisRepository anamnesisRepository = new AnamnesisRepository();
        //private RecipeRepository recipeRepository = new RecipeRepository();
       // private MedicalInstructionRepository medicalInstructionRepository = new MedicalInstructionRepository();
        public MedicalCard() { }
        public MedicalCard(int id)
        {
            this.Id = id;
            //this.allergens = allergenRepository.getAllByMedicalCardId(id);
            //this.anamnesiss = anamnesisRepository.getAllAnamenesisFromSpecificMedicalCardById(id);
            //this.recipes = recipeRepository.getAllRecipesFromSpecificMedicalCardById(id);
            //this.medicalInstructions = medicalInstructionRepository.getAllMedicalInstructionsFromSpecificMedicalCardById(id);
        }
    }
}
