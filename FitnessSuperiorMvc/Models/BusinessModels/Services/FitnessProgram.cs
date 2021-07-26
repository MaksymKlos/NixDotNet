using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services
{
    /// <summary>
    /// Represent all programs.
    /// </summary>
    public abstract class FitnessProgram 
    { 
        /// <summary>
        /// Program name.
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Program description.
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Program price.
        /// </summary>
        public abstract decimal Price { get; }
        /// <summary>
        /// Program reviews.
        /// </summary>
    }
}
