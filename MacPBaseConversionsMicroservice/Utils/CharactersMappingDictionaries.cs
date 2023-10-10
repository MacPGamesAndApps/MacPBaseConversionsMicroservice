using MacPBaseConversionsMicroservice.Models;
using MacPEnumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MacPBaseConversionsMicroservice.Utils
{
    public static class CharactersMappingDictionaries
    {
        private readonly static Dictionary<string, int> _fromCharactersMapping = LoadFromCharactersDictionary();

        private readonly static Dictionary<string, string> _hexaBinaryMapping = LoadHexaBinaryMapping();

        private static Dictionary<string, int> LoadFromCharactersDictionary()
        {
            Dictionary<string, int> fromCharactersMapping = new Dictionary<string, int>();

            foreach (ToCharactersTranslation type in Enum.GetValues(typeof(ToCharactersTranslation)))
            {
                fromCharactersMapping.Add(EnumHelper.GetEnumDisplayName(type), ((int)type));
            }

            return fromCharactersMapping;
        }

        private static Dictionary<string, string> LoadHexaBinaryMapping()
        {
            Dictionary<string, string> hexaBinaryMapping = new Dictionary<string, string>();

            using(DecimalToBinary decimalToBinary = new DecimalToBinary())
            {
                foreach (ToCharactersTranslation type in Enum.GetValues(typeof(ToCharactersTranslation)))
                {
                    hexaBinaryMapping.Add(EnumHelper.GetEnumDisplayName(type), decimalToBinary.ConvertValue(((int)type).ToString()).PadLeft(4, '0'));
                }
            }

            return hexaBinaryMapping;
        }

        public static Dictionary<string, int> FromCharactersMapping { get { return _fromCharactersMapping; } }

        public static Dictionary<string, string> HexaBinaryMapping { get { return _hexaBinaryMapping; } }
    }
}
