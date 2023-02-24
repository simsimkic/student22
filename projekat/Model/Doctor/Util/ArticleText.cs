using ProjekatKlinika.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Model.Doctor.Util
{
    public class ArticleText
    {
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 2000;
        private string VALIDATION_ERROR = string.Format("Invalid input. Article text must contain {0} to {1} characters.", MIN_LENGTH, MAX_LENGTH);

        private string value;
        public string Value
        {
            get => value;
            set
            {
                if (IsTextValid(value))
                    this.value = value;
                else
                    ThrowException();
            }
        }

        public ArticleText(string text)
        {
            if (IsTextValid(text))
                value = text;
            else
                ThrowException();
        }

        private bool IsTextValid(string text)
        {
            if(text != null)
                return text.Length >= MIN_LENGTH && text.Length <= MAX_LENGTH;
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
