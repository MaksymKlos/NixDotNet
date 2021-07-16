using System;
using System.Collections.Generic;
using System.Text;

namespace Models.BusinessModels.Services
{
    public abstract class FitnessProgram 
    { 

        #region Properties
        public abstract string ProgramName { get; }
        public abstract string ProgramDescription { get; }
        public abstract decimal Price { get; }
        public abstract string Destination { get; }
        #endregion
    }
}
