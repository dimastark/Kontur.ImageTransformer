using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer.ImageFilters
{
    public interface IFilter
    {
        void PerformFilter(Image<Rgba32> image);
    }
}
