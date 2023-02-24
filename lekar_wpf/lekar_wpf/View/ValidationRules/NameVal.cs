using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lekar_wpf.View.ValidationRules
{
    class NameVal : ValidationRule
    {
        public NameVal()
        {
            ValidatesOnTargetUpdated = true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string phoneNumber = value as string;
                Regex regex = new Regex("^[A-Z][A-Za-z- ]{0,40}$");
                if (regex.IsMatch(phoneNumber))
                {
                    SettingsPage.fullNameEnabled = true;
                    if (SettingsPage.addressEnabled && SettingsPage.birthDateEnabled && SettingsPage.jmbgEnabled && SettingsPage.fullNameEnabled && SettingsPage.phoneNumberEnabled && SettingsPage.licenceNumberEnabled && SettingsPage.emailEnabled)
                    {
                        SettingsPage.enabled = true;
                    }
                    return new ValidationResult(true, null);
                }
                else
                {
                    SettingsPage.fullNameEnabled = false;
                    SettingsPage.enabled = false;
                    return new ValidationResult(false, null);
                    
                }
            }
            catch
            {
                SettingsPage.fullNameEnabled = false;
                SettingsPage.enabled = false;
                return new ValidationResult(false, "Nepredvidjena greska!");
            }

        }
    }
}