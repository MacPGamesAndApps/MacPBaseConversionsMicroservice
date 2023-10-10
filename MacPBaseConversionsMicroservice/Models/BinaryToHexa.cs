using MacPBaseConversionsMicroservice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MacPBaseConversionsMicroservice.Models
{
    public class BinaryToHexa : Conversions
    {
        public override string ConvertValue(string fromValue)
        {
            //Start by padding with 0's to the left if needed to achieve a number of bits dividable by 4
            //Formula to obtain the total padding number provided by my daughter, Jessica
            fromValue = fromValue.PadLeft((int)(Math.Ceiling(fromValue.Length / 4.0) * 4), '0');
            string[] nibblesArray = fromValue.Chunk(4).ToArray().Select(x => string.Join("", x)).ToArray();

            string convertedValue = string.Empty;

            try
            {
                foreach (string nibble in nibblesArray)
                {
                    string hexaDigit = CharactersMappingDictionaries.HexaBinaryMapping.Where(hbm => hbm.Value == nibble).FirstOrDefault().Key;
                    if (hexaDigit == null)
                    {
                        throw new KeyNotFoundException();
                    }

                    convertedValue += hexaDigit;
                }
            }
            catch (KeyNotFoundException ex)
            {
                convertedValue = string.Format("The value {0} is not a Binary number", fromValue);
            }
            catch (Exception ex)
            {
                convertedValue = ex.Message;
            }

            return convertedValue;
        }
    }
}
