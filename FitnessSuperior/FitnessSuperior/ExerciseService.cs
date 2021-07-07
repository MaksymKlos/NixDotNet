using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LinqToDB;
using LinqToDB.Reflection;
using Models.Dto.FitnessProgram;
using DataContext = System.Data.Linq.DataContext;d

namespace FitnessSuperior
{
    public class ExerciseService:LinkToSql<ExerciseDto>
    {
        public override void Update(ExerciseDto entity)
        {
            db.GetTable<ExerciseDto>()
                .Where(e => e.Id == entity.Id)
                .Set(e=>e.Name,entity.Name)
                .Set(e=>e.MuscleGroups,entity.MuscleGroups)
                .Update();
            db.SubmitChanges();

        }
    }
}
