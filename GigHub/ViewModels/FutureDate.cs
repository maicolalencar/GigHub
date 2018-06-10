using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateOut;// = new DateTime();
            var isValid = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateOut);
            return (isValid && dateOut > DateTime.Now);
        }
    }
}