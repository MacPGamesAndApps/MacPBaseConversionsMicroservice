using MacPBaseConversionsMicroservice.Utils;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MacPBaseConversionsMicroservice.Models
{
    public class HexaToBinary : Conversions
    {
        public override string ConvertValue(string fromValue)
        {
            string convertedValue = string.Empty;
            char[] fromDigitsArray = fromValue.ToArray();

            try
            {
                foreach(char c in fromDigitsArray)
                {
                    convertedValue += CharactersMappingDictionaries.HexaBinaryMapping[c.ToString()];
                }
            }
            catch (KeyNotFoundException ex)
            {
                convertedValue = string.Format("The value {0} is not an Hexadecimal number", fromValue);
            }
            catch (Exception ex)
            {
                convertedValue = ex.Message;
            }

            return convertedValue;
        }
    }
}
