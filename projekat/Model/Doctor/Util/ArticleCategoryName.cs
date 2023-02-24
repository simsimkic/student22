using ProjekatKlinika.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Model.Doctor.Util
{
    public class ArticleCategoryName
    {
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 100;
        private string VALIDATION_ERROR = string.Format("Invalid input. Category name must contain {0} to {1} characters.", MIN_LENGTH, MAX_LENGTH);

        private string value;
        public string Value
        {
            get => value;
            set
            {
                if (IsNameValid(value))
                    this.value = value;
                else
                    ThrowException();
            }
        }

        public ArticleCategoryName(string name)
        {
            if (IsNameValid(name))
                value = name;
            else
                ThrowException();
        }

        private bool IsNameValid(string name)
        {
            if (name != null)
                return name.Length >= MIN_LENGTH && name.Length <= MAX_LENGTH;
            else
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