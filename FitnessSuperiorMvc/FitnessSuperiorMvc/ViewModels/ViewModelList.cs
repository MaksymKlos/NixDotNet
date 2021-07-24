using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessSuperiorMvc.WEB.ViewModels.Interfaces;

namespace FitnessSuperiorMvc.WEB.ViewModels
{
    public class ViewModelList
    {
        private ICollection<IViewModel> Models { get; set; }

        public ViewModelList(ICollection<IViewModel> models)
        {
            Models = models;
        }
    }
}
