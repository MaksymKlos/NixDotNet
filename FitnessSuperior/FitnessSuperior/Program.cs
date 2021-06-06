using System;
using System.Collections.Generic;
using DataAccess.EF;
using Models.Business.People;
using Models.Business.Services;
using Models.Helpers;

namespace FitnessSuperior
{
    class Program
    {
        static void Main(string[] args)
        {
           using(FitnessAppContext context = new FitnessAppContext())
           {
               context.Database.EnsureDeleted();
               context.Database.EnsureCreated();

               List<Exercise> mondayExercises = new List<Exercise>()
               {
                   new Exercise("Bench press", "Chest, triceps"),
                   new Exercise("Wiring", "Chest"),
                   new Exercise("Push-ups", "Chest,triceps,shoulders")
               };
               List<Exercise> wednesdayExercises = new List<Exercise>()
               {
                   new Exercise("Lifting dumbbells for biceps","biceps"),
                   new Exercise("Biceps machine", "biceps"),
                   new Exercise("Squats","Legs")
               };
               List<Exercise> fridayExercises = new List<Exercise>()
               {
                   new Exercise("Pull-ups", "Back,shoulders"),
                   new Exercise("Upper block link", "Back, rear delta"),
                   new Exercise("Overhead dumbbell press", "Shoulders")
               };
               Trainer trainer = new Trainer(
                   "desda1f2",
                   "John",
                   new DateTime(1990, 3, 12),
                   "sd@gmail.com",
                   new DateTime(2003, 12, 23),
                   "Kharkiv State Academy of Physical Culture",
                   "fitness",
                   "both");
               List<SetOfExercise> sets = new List<SetOfExercise>()
               {
                   trainer.CreateSetOfExercise("Chest standard", "Chest, triceps", mondayExercises),
                   trainer.CreateSetOfExercise("Biceps+Legs", "Buttocks, hamstrings, biceps", wednesdayExercises),
                   trainer.CreateSetOfExercise("Powerful back", "Back, shoulders", fridayExercises)
               };
               var trainingProgram = trainer.CreateTrainingProgram("Default",
                   "For beginners",
                   "Muscle gain",
                   "Beginner",
                   null,
                   sets,
                   1000.0m);

                CommonUser user = new CommonUser(
                   "Maxvel",
                   "Max",
                   DateTime.Parse("22.10.2002"),
                   "klosmax62@gmail.com")
               {
                   SecondName = "Klos",
                   PhoneNumber = "+380663209866",
                   TrainingPrograms = new List<TrainingProgram>() { trainingProgram}
               };
                context.Exercises.Add(mondayExercises[0].ModelToDto());
                context.Exercises.Add(mondayExercises[1].ModelToDto());
                context.Exercises.Add(mondayExercises[2].ModelToDto());

                context.Exercises.Add(wednesdayExercises[0].ModelToDto());
                context.Exercises.Add(wednesdayExercises[1].ModelToDto());
                context.Exercises.Add(wednesdayExercises[2].ModelToDto());

                context.Exercises.Add(fridayExercises[0].ModelToDto());
                context.Exercises.Add(fridayExercises[1].ModelToDto());
                context.Exercises.Add(fridayExercises[2].ModelToDto());

                context.SetOfExercises.Add(sets[0].ModelToDto());
                context.SetOfExercises.Add(sets[1].ModelToDto());
                context.SetOfExercises.Add(sets[2].ModelToDto());

                context.TrainingPrograms.Add(trainingProgram.ModelToDto());

                context.Trainers.Add(trainer.ModelToDto());

                context.Users.Add(user.ModelToDto());
                context.SaveChanges();

           }
        }
    }
}
