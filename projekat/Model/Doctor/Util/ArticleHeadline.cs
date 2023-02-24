using ProjekatKlinika.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Model.Doctor.Util
{
    public class ArticleHeadline
    {
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 200;
        private string VALIDATION_ERROR = string.Format("Invalid input. Article headline must contain {0} to {1} characters.", MIN_LENGTH, MAX_LENGTH);

        private string value;
        public string Value
        {
            get => value;
            set
            {
                if (IsHeadlineValid(value))
                    this.value = value;
                else
                    ThrowException();
            }
        }

        public ArticleHeadline(string headline)
        {
            if (IsHeadlineValid(headline))
                value = headline;
            else
                ThrowException();
        }

        private bool IsHeadlineValid(string headline)
        {
            if(headline != null)
                return headline.Length >= MIN_LENGTH && headline.Length <= MAX_LENGTH;
            return true;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public void ThrowException()
        {
            throw new ValidationException(VALIDATION_ERROR);
        }
    }
}
