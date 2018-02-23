using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer.ImageFilters
{
    public class Sepia : ImageFilter
    {
        public Sepia(FilterParameters parameters) : base(parameters)
        {
        }

        public override void PerformFilter(Image<Rgba32> image)
        {
            base.PerformFilter(image);
            image.Mutate(x => x.Sepia());
        }
    }
}
