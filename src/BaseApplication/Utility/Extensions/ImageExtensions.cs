using SkiaSharp;
using Utility.Helper;

namespace Utility.Extensions
{
    public static class ImageExtensions
    {

        public static string ToBase64(this SKData sKData)
        {
            if (sKData is null)
                throw new ArgumentNullException(nameof(sKData));

            return FileHelper.GetBase64Image(sKData.ToArray());
        }
    }
}
