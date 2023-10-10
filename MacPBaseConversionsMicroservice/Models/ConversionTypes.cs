using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MacPBaseConversionsMicroservice.Models
{
    public enum ConversionTypes : Byte
    {
        [Display(Name = "Decimal to hexadecimal")]
        decimal_to_hexa = 0,
        [Display(Name = "Decimal to octal")]
        decimal_to_octal,
        [Display(Name = "Decimal to binary")]
        decimal_to_binary,
        [Display(Name = "Hexadecimal to decimal")]
        hexa_to_decimal,
        [Display(Name = "Octal to decimal")]
        octal_to_decimal,
        [Display(Name = "Binary to decimal")]
        binary_to_decimal,
        [Display(Name = "Hexadecimal to binary")]
        hexa_to_binary,
        [Display(Name = "Binary to hexadecimal")]
        binary_to_hexa
    }
}
