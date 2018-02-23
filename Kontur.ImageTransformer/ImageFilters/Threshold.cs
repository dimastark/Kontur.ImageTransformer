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

        public override void PerformFilter(Image<Rgba32> image)
        {
            base.PerformFilter(image);
            image.Mutate(x => x.BinaryThreshold(thresholdX));
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
