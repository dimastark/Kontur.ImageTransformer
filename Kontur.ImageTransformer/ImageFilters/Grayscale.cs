using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer.ImageFilters
{
    public class Grayscale : ImageFilter
    {
        public Grayscale(FilterParameters parameters) : base(parameters)
        {
        }

        public override Image<Rgba32> PerformFilter(Image<Rgba32> image)
        {
            base.PerformFilter(image).Mutate(x => x.Grayscale());

            return image;
        }
    }
}
