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
    class BirthDateVal : ValidationRule
    {
        public BirthDateVal()
        {
            ValidatesOnTargetUpdated = true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string phoneNumber = value as string;
                
                if (DateTime.TryParseExact(phoneNumber, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    SettingsPage.birthDateEnabled = true;
                    if (SettingsPage.addressEnabled && SettingsPage.birthDateEnabled && SettingsPage.jmbgEnabled && SettingsPage.fullNameEnabled && SettingsPage.phoneNumberEnabled && SettingsPage.licenceNumberEnabled && SettingsPage.emailEnabled)
                    {
                        SettingsPage.enabled = true;
                    }
                    return new ValidationResult(true, null);
                }
                else
                {
                    SettingsPage.birthDateEnabled = false;
                    SettingsPage.enabled = false;
                    return new ValidationResult(false, null);
                }
            }
            catch
            {
                SettingsPage.birthDateEnabled = false;
                SettingsPage.enabled = false;
                return new ValidationResult(false, "Nepredvidjena greska!");
            }

        }
    }
}
