using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        private const string Format = "HH:mm";

        public override bool IsValid(object value)
        {
            DateTime dateOut;// = new DateTime();
            var isValid = DateTime.TryParseExact(value.ToString(), Format, CultureInfo.CurrentCulture, DateTimeStyles.None, out dateOut);
            return (isValid && dateOut > DateTime.Now);
        }
    }
}