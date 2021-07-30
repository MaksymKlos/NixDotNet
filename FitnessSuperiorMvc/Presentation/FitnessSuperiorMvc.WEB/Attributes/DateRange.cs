using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace FitnessSuperiorMvc.WEB.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DateRange:RangeAttribute
    {
        private new string ErrorMessageString { get; set; }
        public DateRange(string minimumValue):base(typeof(DateTime), minimumValue, DateTime.Now.ToShortDateString())
        {
            ErrorMessageString = $"Date must be between {minimumValue} and {DateAndTime.Now.ToShortDateString()}";
        }

        public override string FormatErrorMessage(string name)
        {
            
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Minimum, Maximum);
        }
        

    }
}
