using System;
using System.Text.RegularExpressions;

namespace FitnessSuperiorMvc.BLL.Dto.Programs.Sport
{
    /// <summary>
    /// Represents exercise.
    /// </summary>
    public class ExerciseDto
    {
        /// <summary>
        /// The name of the exercise.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Muscles that are used during the exercise.
        /// </summary>
        public string MuscleGroups { get; }
        /// <summary>
        /// Exercise description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Link to YouTube video with this exercise.
        /// </summary>
        public string YoutubeUrl { get; set; }

        /// <summary>
        /// Exercise creation.
        /// </summary>
        /// <param name="name">The name of the exercise.</param>
        /// <param name="muscleGroups">Muscles that are used during the exercise.</param>
        /// <param name="description">Exercise description</param>
        public ExerciseDto(string name, string muscleGroups, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(muscleGroups))
            {
                throw new ArgumentException("Muscle groups can't be empty or null.", nameof(muscleGroups));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description can't be empty or null.", nameof(muscleGroups));
            }

            Name = name;
            MuscleGroups = muscleGroups;
            Description = description;

        }
        public ExerciseDto(string name, string muscleGroups, string description, string youtubeUrl) : this(name, muscleGroups, description)
        {

            Regex regex = new Regex(@"^(?:https?\:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v\=))([\w-]{10,12})(?:$|\&|\?\#).*");
            if (regex.IsMatch(youtubeUrl))
            {
                YoutubeUrl = youtubeUrl.Replace("watch?v=", "embed/");
            }
        }
    }
}
