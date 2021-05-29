using System;
using System.Collections.Generic;
using System.Text;
namespace Models.Interaction
{
    public class Subscription
    {
        #region Fields
        private readonly DateTime _subscriptionStartDate;
        #endregion

        #region Properties
        public int SubscriptionId { get; set; }
        public int PersonId { get; set; }
        public int? NutritionProgramId { get; set; }
        public int? TrainingProgramId { get; set; }
        public TimeSpan SubscriptionDuration => CalculateDuration(_subscriptionStartDate);
        #endregion

        #region Constructors
        #endregion

        #region Methods

        private TimeSpan CalculateDuration(DateTime startDate) => DateTime.Now - startDate;


        #endregion


    }
    
}
