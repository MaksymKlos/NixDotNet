namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport
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
