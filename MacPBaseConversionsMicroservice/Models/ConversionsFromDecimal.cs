using MacPBaseConversionsMicroservice.Utils;
using MacPEnumHelpers;

namespace MacPBaseConversionsMicroservice.Models
{
    public class ConversionsFromDecimal : Conversions
    {
        private readonly int _toBase;

        public ConversionsFromDecimal(int toBase)
        {
            _toBase = toBase;
        }

        public override string ConvertValue(string fromValue)
        {
            string convertedValue = string.Empty;
            long numericFromValue = 0;

            if (long.TryParse(fromValue, out numericFromValue))
            {
                do
                {
                    convertedValue = (EnumHelper.GetEnumDisplayName((ToCharactersTranslation)(numericFromValue % _toBase)) + convertedValue);
                    numericFromValue = numericFromValue / _toBase;
                } while (numericFromValue >= _toBase);
                if (numericFromValue > 0)
                {
                    convertedValue = (EnumHelper.GetEnumDisplayName((ToCharactersTranslation)(numericFromValue % _toBase)) + convertedValue);
                }
            }

            return convertedValue;
        }
    }
}
