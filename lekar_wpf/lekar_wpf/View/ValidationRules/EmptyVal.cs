using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lekar_wpf.View.ValidationRules
{
    class EmptyVal : ValidationRule
    {
        public EmptyVal()
        {
            ValidatesOnTargetUpdated = true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                if (!text.Equals(""))
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, null);
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepredvidjena greska!");
            }

        }
    }
}
