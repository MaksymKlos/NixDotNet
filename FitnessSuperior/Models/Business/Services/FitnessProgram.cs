namespace Models.Business.Services
{
    public abstract class FitnessProgram<T>
    {
        #region Properties
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract T Specialist { get; }
        public abstract decimal Price { get; }
        public abstract string Destination { get; }
        #endregion

        #region Methods
        public abstract string GetInfoAboutProgram();
        #endregion
    }
}
