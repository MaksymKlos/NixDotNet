using System;
using Models.Interfaces;
using Models.Business.People;


namespace Models.Business.Interaction
{
    public class Feedback
    {
        #region Fields
        private string _textOfComment;
        #endregion

        #region Properties
        public IPersonData Commentator { get; }
        public int Rate { get; }

        public string TextOfComment
        {
            get
            {
                if (_textOfComment == null)
                {
                    throw new ArgumentNullException(nameof(_textOfComment),
                        "Text has not assigned the value.");
                }

                return _textOfComment;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Text can't be empty or null.", nameof(value));
                }

                _textOfComment = value;
            }
        }

        #endregion
        #region Constructors

        public Feedback(Person commentator, int rate, string textOfComment)
        {
            if (rate <= 0 || rate > 5)
            {
                throw new ArgumentException("Impossible rate value", nameof(rate));
            } 
            Commentator = commentator ?? throw new ArgumentNullException(
                nameof(commentator), "Commentator can't be null");
            Rate = rate;
            TextOfComment = textOfComment;
        }
        #endregion
        #region Methods

        public void ChangeText(string text)
        {
            TextOfComment = text;
        }
        #endregion


    }
}
