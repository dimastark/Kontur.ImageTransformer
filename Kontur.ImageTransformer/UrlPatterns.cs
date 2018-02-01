namespace Kontur.ImageTransformer
{
    public static class UrlPatterns
    {
        public const string GrayscaleFilter = @"(?<filter>grayscale)";
        public const string SepiaFilter = @"(?<filter>sepia)";
        public const string ThresholdFilter = @"(?<filter>threshold)\((?<param>100|[1-9]?[0-9])\)";
        public const string Coordinates = @"{x:int},{y:int},{w:int},{h:int}";
    }
}
