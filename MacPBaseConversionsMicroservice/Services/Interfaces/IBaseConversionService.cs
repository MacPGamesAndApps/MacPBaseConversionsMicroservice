using MacPBaseConversionsMicroservice.Models;
using System.Collections.Generic;

namespace MacPBaseConversionsMicroservice.Services.Interfaces
{
    public interface IBaseConversionService
    {
        string ConvertValue(string valueFrom, ConversionTypes conversionType);
        IEnumerable<ConversionTypeNamed> GetTypes();
    }
}
