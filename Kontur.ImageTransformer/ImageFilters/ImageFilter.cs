using SixLabors.ImageSharp;
using SixLabors.Primitives;

namespace Kontur.ImageTransformer.ImageFilters
{
    public abstract class ImageFilter : IFilter
    {
        private readonly Rectangle cropRectangle;
        
        protected ImageFilter(FilterParameters parameters)
        {
            cropRectangle = new Rectangle(
                parameters.X, 
                parameters.Y, 
                parameters.Width, 
                parameters.Height
            );
        }

        public virtual Image<Rgba32> PerformFilter(Image<Rgba32> image)
        {
            image.Mutate(x => x.Crop(cropRectangle));

            return image;
        }
    }

    public class FilterParameters
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Width;
        public readonly int Height;

        public FilterParameters(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
