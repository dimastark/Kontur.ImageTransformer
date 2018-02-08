using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer.ImageFilters
{
    public class Threshold : ImageFilter
    {
        private readonly int thresholdX;
        
        public Threshold(ThresholdParameters parameters) : base(parameters)
        {
            thresholdX = parameters.ThresholdX;
        }

        public override Image<Rgba32> PerformFilter(Image<Rgba32> image)
        {
            base.PerformFilter(image).Mutate(x => x.BinaryThreshold(thresholdX));

            return image;
        }
    }
    
    public class ThresholdParameters : FilterParameters
    {
        public readonly int ThresholdX;
        
        public ThresholdParameters(int x, int y, int width, int height, int thresholdX) : base(x, y, width, height)
        {
            ThresholdX = thresholdX;
        }
    }
}
