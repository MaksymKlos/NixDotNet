using System;
using System.Collections.Generic;
using System.Text;
using Models.People;

namespace Models.Services
{
    public abstract class FitnessProgram<T> where T:Staff
    {
        #region Properties
        public abstract string ProgramName { get; }
        public abstract string ProgramDescription { get;}
        public abstract T Specialist { get;}
        #endregion

        #region Methods
        public abstract void GetInfoAboutProgram();
        #endregion
    }
}
