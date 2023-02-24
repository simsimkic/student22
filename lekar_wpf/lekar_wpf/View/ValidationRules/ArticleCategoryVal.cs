using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lekar_wpf.View.ValidationRules
{
    class ArticleCategoryVal : ValidationRule
    {
        public ArticleCategoryVal()
        {
            ValidatesOnTargetUpdated = true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if(value != null)
                {
                    string newCategory = value as string;
                    if (newCategory.Length > 50)
                    {
                        return new ValidationResult(false, "Naziv predugacak!");
                    }
                    if (newCategory.Equals(""))
                    {
                        return new ValidationResult(false, "Naziv kategorije mora sadrzati barem jedan karakter!");
                    }
                    bool exists = false;
                    foreach (ArticleCategory c in BlogPage.Categories)
                    {
                        if (c.Name.Equals(newCategory))
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (exists)
                    {
                        return new ValidationResult(false, "Kategorija vec postoji");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                } else
                {
                    return new ValidationResult(false, null);
                }
            }
            catch
            {
                SettingsPage.addressEnabled = false;
                SettingsPage.enabled = false;
                return new ValidationResult(false, "Nepredvidjena greska!");
            }

        }
    }
}
