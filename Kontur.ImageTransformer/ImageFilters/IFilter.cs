using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer.ImageFilters
{
    public interface IFilter
    {
        Image<Rgba32> PerformFilter(Image<Rgba32> image);
    }
}
