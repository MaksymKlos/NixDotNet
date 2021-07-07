using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Dto.FitnessProgram;
using Models.Interfaces;

namespace Models.ViewModels
{
    public class ExistingProgramsViewModel<T> where T:FitnessProgramDto
    {
        public IEnumerable<T> ExistingPrograms { get; set; }
        public int WorkoutPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PreviousPage => CurrentPage - 1;
        public int NextPage => CurrentPage + 1;

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(ExistingPrograms.Count() / (double)WorkoutPerPage));
        }
        public IEnumerable<T> PaginatedPrograms
        {
            get
            {
                int start = (CurrentPage - 1) * WorkoutPerPage;
                return ExistingPrograms.OrderBy(b => b.Id).Skip(start).Take(WorkoutPerPage);
            }
        }
    }
}
