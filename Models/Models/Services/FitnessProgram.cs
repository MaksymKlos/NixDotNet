using Models.People;

namespace Models.Services
{
    public abstract class FitnessProgram<T> where T:Staff
    {
        #region Properties
        public abstract string ProgramName { get; }
        public abstract string ProgramDescription { get;}
        public abstract T Specialist { get;}
        public abstract decimal Price { get; }
        public abstract string Destination { get; }
        #endregion

        #region Methods
        public abstract string GetInfoAboutProgram();
        #endregion
    }
}
