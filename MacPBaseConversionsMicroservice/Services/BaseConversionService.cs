using MacPBaseConversionsMicroservice.Models;
using MacPBaseConversionsMicroservice.Services.Interfaces;
using MacPEnumHelpers;
using System.Collections.Generic;
using System;

namespace MacPBaseConversionsMicroservice.Services
{
    public class BaseConversionService : IBaseConversionService
    {
        public string ConvertValue(string valueFrom, ConversionTypes conversionType)
        {
            string convertedValue = String.Empty;
            Conversions? conversion = null;

            switch(conversionType)
            {
                case ConversionTypes.decimal_to_hexa:
                    conversion = new DecimalToHexa();
                    break;
                case ConversionTypes.decimal_to_octal:
                    conversion = new DecimalToOctal();
                    break;
                case ConversionTypes.decimal_to_binary:
                    conversion = new DecimalToBinary();
                    break;
                case ConversionTypes.hexa_to_decimal:
                    conversion = new HexaToDecimal();
                    break;
                case ConversionTypes.octal_to_decimal:
                    conversion = new OctalToDecimal();
                    break;
                case ConversionTypes.binary_to_decimal:
                    conversion = new BinaryToDecimal();
                    break;
                case ConversionTypes.hexa_to_binary:
                    conversion = new HexaToBinary();
                    break;
                case ConversionTypes.binary_to_hexa:
                    conversion = new BinaryToHexa();
                    break;
            }

            if (conversion != null)
            {
                convertedValue = conversion.ConvertValue(valueFrom);
            }

            return convertedValue;
        }

        public IEnumerable<ConversionTypeNamed> GetTypes()
        {
            List<ConversionTypeNamed> types = new List<ConversionTypeNamed>();

            foreach (ConversionTypes type in Enum.GetValues(typeof(ConversionTypes)))
            {
                types.Add(new ConversionTypeNamed { ConversionName = EnumHelper.GetEnumDisplayName(type), ConversionType = type });
            }

            return types;
        }
    }
}
