using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Interfaces;
using FitnessSuperiorMvc.WEB.ViewModels.Interfaces;

namespace FitnessSuperiorMvc.WEB.ViewModels.Page
{
    public class PaginationViewModel<T>:IViewModel where T:IKey
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
