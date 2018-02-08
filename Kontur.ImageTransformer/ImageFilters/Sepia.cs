using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer.ImageFilters
{
    public class Sepia : ImageFilter
    {
        public Sepia(FilterParameters parameters) : base(parameters)
        {
        }

        public override Image<Rgba32> PerformFilter(Image<Rgba32> image)
        {
            base.PerformFilter(image).Mutate(x => x.Sepia());

            return image;
        }
    }
}
