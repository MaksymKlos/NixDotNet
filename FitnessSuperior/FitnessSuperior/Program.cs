using System;
using System.Collections.Generic;
using DataAccess.EF;
using Models.Business.People;
using Models.Business.Services;
using Models.Helpers;
using Models.Dto.Person;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Linq;
using LinqToDB.Reflection;
using Models.Dto.FitnessProgram;


namespace FitnessSuperior
{
    class Program
    {
        private static string connectionString =
            @"Data Source=MAXVEL\SQLEXPRESS;Initial Catalog=LinqToDb;Integrated Security=True";
        static async Task Main(string[] args)
        {
            
                #region Programs

                List<Exercise> mondayExercises = new List<Exercise>()
                {
                    new Exercise("Bench press", "Chest, triceps"),
                    new Exercise("Wiring", "Chest"),
                    new Exercise("Push-ups", "Chest,triceps,shoulders")
                };
                List<Exercise> wednesdayExercises = new List<Exercise>()
                {
                    new Exercise("Lifting dumbbells for biceps", "biceps"),
                    new Exercise("Biceps machine", "biceps"),
                    new Exercise("Squats", "Legs")
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
                

                #endregion

                #region Users

                UserDto user1 = new CommonUser(
                    "Maxvel2",
                    "Max",
                    DateTime.Parse("22.10.2002"),
                    "klosmax62@gmail.com").ModelToDto();
                user1.TrainingPrograms = new List<TrainingProgram>() {trainingProgram};
                user1.Balance = 100.0m;
                user1.SecondName = "Klos";

                UserDto user2 = new CommonUser(
                    "Rfss",
                    "Sergey",
                    DateTime.Parse("12.03.2000"),
                    "Rfss_sergey@mail.ru").ModelToDto();
                user2.TrainingPrograms = new List<TrainingProgram>() {trainingProgram};
                user2.PhoneNumber = "+380663209866";

                UserDto user3 = new VipUser(
                    "gds",
                    "Alex",
                    DateTime.Parse("14.10.2001"),
                    "sd@mail.ru").ModelToDto();
                user2.TrainingPrograms = new List<TrainingProgram>() {trainingProgram};
                user2.PhoneNumber = "+380663209866";

                UserDto user4 = new VipUser(
                    "Sfafa",
                    "Nikita",
                    DateTime.Parse("12.04.2000"),
                    "dwfq@gmail.com").ModelToDto();

                #endregion

                Regex regexStatus = new Regex("VIP");
                Regex regexMail = new Regex(@"\w*gmail.com");

                #region Threads

                ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 },
                    Factorial);

                


                #endregion

                #region Serialization

                Console.WriteLine();
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                var usersList = new List<UserDto>()
                {
                    user1,
                    user2,
                    user3,
                    user4
                };
                using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync<ICollection<UserDto>>(fs, usersList, options);

                    Console.WriteLine("Data has been saved to file.");
                }

                using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                {
                    var restoredUsers = await JsonSerializer.DeserializeAsync<ICollection<UserDto>>(fs);
                    foreach (var user in restoredUsers)
                    {
                        if (regexStatus.IsMatch(user.Status))
                        {
                            Console.WriteLine($"Name: {user.Name}, age: {user.Age}, email: {user.Email}");
                        }


                        if (regexMail.IsMatch(user.Email))
                        {
                            Console.WriteLine($"Login: {user.Login} Mail: {user.Email}");
                        }

                    }

                }



            #endregion

            #region DataBase
            //Linq to Db
            Console.WriteLine();
            List<ExerciseDto> listOfExercises = new List<ExerciseDto>()
            {
                new Exercise("Bench press", "Chest, triceps").ModelToDto(),
                new Exercise("Wiring", "Chest").ModelToDto(),
                new Exercise("Push-ups", "Chest,triceps,shoulders").ModelToDto()
            };
            var db = new LinkToSql<ExerciseDto>();
            foreach (var exercise in listOfExercises)
            {
                Console.WriteLine(db.Create(exercise).Name);
            }
            db.Remove(3);
            

            //Entity Framework
            //await using (FitnessAppContext context = new FitnessAppContext())
            //{
            //}
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //context.Exercises.Add(mondayExercises[0].ModelToDto());
            //context.Exercises.Add(mondayExercises[1].ModelToDto());
            //context.Exercises.Add(mondayExercises[2].ModelToDto());

            //context.Exercises.Add(wednesdayExercises[0].ModelToDto());
            //context.Exercises.Add(wednesdayExercises[1].ModelToDto());
            //context.Exercises.Add(wednesdayExercises[2].ModelToDto());

            //context.Exercises.Add(fridayExercises[0].ModelToDto());
            //context.Exercises.Add(fridayExercises[1].ModelToDto());
            //context.Exercises.Add(fridayExercises[2].ModelToDto());

            //context.SetOfExercises.Add(sets[0].ModelToDto());
            //context.SetOfExercises.Add(sets[1].ModelToDto());
            //context.SetOfExercises.Add(sets[2].ModelToDto());

            //context.TrainingPrograms.Add(trainingProgram.ModelToDto());

            //context.Trainers.Add(trainer.ModelToDto());

            //context.Users.Add(user.ModelToDto());
            //context.SaveChanges();


            #endregion



            static void Factorial(int x)
            {
                int result = 1;

                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Console.WriteLine($"Факториал числа {x} равен {result}");
                Thread.Sleep(3000);
            }

        }
    }
    public class Counter
    {
        private readonly int _x;
        private readonly int _y;

        public Counter(int x, int y)
        {
            _x=x;
            _y=y;
        }

        public void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * _x * _y);
                Thread.Sleep(400);
            }
        }
    }
}
