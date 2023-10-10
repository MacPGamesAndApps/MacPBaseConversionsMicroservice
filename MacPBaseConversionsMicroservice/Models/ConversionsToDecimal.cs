using MacPBaseConversionsMicroservice.Utils;
using MacPEnumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MacPBaseConversionsMicroservice.Models
{
    public class ConversionsToDecimal : Conversions
    {
        private readonly int _fromBase;

        public ConversionsToDecimal(int fromBase)
        {
            _fromBase = fromBase;
        }

        public override string ConvertValue(string fromValue)
        {
            string convertedValue = string.Empty;
            long numericConvertedValue = 0;

            char[] fromDigitsArray = fromValue.ToArray();
            int maxPow = fromDigitsArray.Length - 1;
            try
            {
                for (int iCount = 0; iCount <= maxPow; iCount++)
                {
                    int fromDigit = CharactersMappingDictionaries.FromCharactersMapping[fromDigitsArray[iCount].ToString()];
                    if (fromDigit < _fromBase)
                    {
                        numericConvertedValue += ((long)Math.Pow(_fromBase, (maxPow - iCount)) * fromDigit);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                convertedValue = numericConvertedValue.ToString();
            }
            catch (KeyNotFoundException ex)
            {
                convertedValue = string.Format("The value {0} is not in base {1}", fromValue, _fromBase);
            }
            catch (Exception ex) 
            {
                convertedValue = ex.Message;
            }

            return convertedValue;
        }
    }
}
