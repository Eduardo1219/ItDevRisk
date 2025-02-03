using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItDevRisk.Helpers
{
    public static class Helper
    {
        public static (bool, DateTime) TryParseValidDate(this string inpt)
        {
            if (string.IsNullOrEmpty(inpt)) return (false, DateTime.MinValue);
            var validInpt = DateTime.TryParseExact(inpt, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

            return (validInpt, result);
        }

        public static (bool, int) TryParseValidInt(this string inpt)
        {
            if (string.IsNullOrEmpty(inpt)) return (false, 0);
            var validInpt = int.TryParse(inpt, out int result);

            return (validInpt, result);
        }

        public static (bool, decimal) TryParseValidDecimal(this string inpt)
        {
            if (string.IsNullOrEmpty(inpt)) return (false, decimal.MinValue);
            var validInpt = decimal.TryParse(inpt, out decimal result);

            return (validInpt, result);
        }

        public static (bool, T?) GetValueFromDescription<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (string.Equals(attribute.Description, description, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return (true, (T)Enum.Parse(typeof(T), field.Name));
                    }
                }
            }
            return (false, default);
        }
    }
}
