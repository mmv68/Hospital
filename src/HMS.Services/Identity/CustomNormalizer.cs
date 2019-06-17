using Microsoft.AspNetCore.Identity;
using HMS.Common.PersianToolkit;
using DNTPersianUtils.Core;

namespace HMS.Services.Identity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2579
    /// </summary>
    public class CustomNormalizer : UpperInvariantLookupNormalizer
    {
        public override string Normalize(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }
            key = key.Trim();

                key = key.ApplyCorrectYeKe()
                     .RemoveDiacritics()
                     .CleanUnderLines()
                     .RemovePunctuation();
                key = key.Trim().Replace(" ", "");

            key = key.ToUpperInvariant();
            return key;
        }
    }
}