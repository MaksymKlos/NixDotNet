using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Community
{
    /// <summary>
    /// Represents comments to staff or program.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Name of user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Text of comment.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Create feedback.
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="text">Text of comment.</param>
        public Feedback(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}
