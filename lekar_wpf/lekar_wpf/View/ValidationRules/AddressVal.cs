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
    class AddressVal : ValidationRule
    {
        public AddressVal()
        {
            ValidatesOnTargetUpdated = true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string phoneNumber = value as string;
                Regex regex = new Regex("[A-Z]{1}[a-zA-Z ]{0,50}( [0-9]{0,6}){0,1},( ){0,1}[A-Z]{1}[a-zA-Z ]{0,50}$");
                if (regex.IsMatch(phoneNumber))
                {
                    SettingsPage.addressEnabled = true;
                    if(SettingsPage.addressEnabled && SettingsPage.birthDateEnabled && SettingsPage.jmbgEnabled && SettingsPage.fullNameEnabled && SettingsPage.phoneNumberEnabled && SettingsPage.licenceNumberEnabled && SettingsPage.emailEnabled)
                    {
                        SettingsPage.enabled = true;
                    }
                    return new ValidationResult(true, null);
                }
                else
                {
                    SettingsPage.addressEnabled = false;
                    SettingsPage.enabled = false;
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

