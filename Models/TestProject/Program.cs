using System;
using System.Collections.Generic;
using Models.People;
using Models.Services;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine(trainingProgram.GetInfoAboutProgram());
          }
    }
}
