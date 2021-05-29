using System;
using System.Collections.Generic;
using System.Text;
using Models.People;

namespace Models.Services
{
    public class NutritionProgram:FitnessProgram<Nutritionist>
    {
        #region Fields

        private ICollection<MealPlan> _mealPlans;

        #endregion

        #region Properties
        public int Id { get; set; }
        public override string ProgramName { get; }
        public override string ProgramDescription { get; }
        public override Nutritionist Specialist { get; }
        public string TypeOfDiet { get; }

        public ICollection<MealPlan> MealPlans
        {
            get
            {
                if (_mealPlans != null)
                {
                    return _mealPlans;
                }

                throw new ArgumentNullException(nameof(_mealPlans), "Meal plans has not assigned a value");
            }
            set => _mealPlans = value ?? throw new ArgumentNullException(nameof(value), "MealPlans can't be null");
        }

        #endregion


        #region Constructors

        public NutritionProgram(string programName,
            string programDescription,
            Nutritionist specialist,
            string typeOfDiet,
            ICollection<MealPlan> mealPlans)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                throw new ArgumentException("The name of program can't be empty or null.", nameof(programName));
            }
            if (string.IsNullOrWhiteSpace(programDescription))
            {
                throw new ArgumentException("The description of program can't be empty or null.", nameof(programDescription));
            }
            if (string.IsNullOrWhiteSpace(typeOfDiet))
            {
                throw new ArgumentException("The type of diet can't be empty or null.", nameof(typeOfDiet));
            }
            Specialist = specialist ?? throw new ArgumentNullException(nameof(specialist), "Specialist can't be null");
            MealPlans = mealPlans;
            ProgramName = programName;
            ProgramDescription = programDescription;
            Specialist = specialist;
            TypeOfDiet = typeOfDiet;
        }


        #endregion

        #region Methods
        public override void GetInfoAboutProgram()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
