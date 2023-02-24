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
    class EmailVal : ValidationRule
    {
        public EmailVal()
        {
            ValidatesOnTargetUpdated = true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string phoneNumber = value as string;
                Regex regex = new Regex("[0-9a-zA-Z._]{1,20}@[0-9a-zA-Z.]{1,20}$");
                if (regex.IsMatch(phoneNumber))
                {
                    SettingsPage.emailEnabled = true;
                    if (SettingsPage.addressEnabled && SettingsPage.birthDateEnabled && SettingsPage.jmbgEnabled && SettingsPage.fullNameEnabled && SettingsPage.phoneNumberEnabled && SettingsPage.licenceNumberEnabled && SettingsPage.emailEnabled)
                    {
                        SettingsPage.enabled = true;
                    }
                    return new ValidationResult(true, null);
                }
                else
                {
                    SettingsPage.emailEnabled = false;
                    SettingsPage.enabled = false;
                    return new ValidationResult(false, null);
                }
            }
            catch
            {
                SettingsPage.emailEnabled = false;
                SettingsPage.enabled = false;
                return new ValidationResult(false, "Nepredvidjena greska!");
            }

        }
    }
}
