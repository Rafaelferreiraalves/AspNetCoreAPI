using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Helpers
{
    public static class DatetimeExtesions
    {
        public static int GetCurrentAge(this DateTime datetime)
        {
            var currentData = DateTime.UtcNow;

            int age = currentData.Year - datetime.Year;

            if (currentData < datetime.AddYears(age))
                age--;
            return age;
        }
    }
}
