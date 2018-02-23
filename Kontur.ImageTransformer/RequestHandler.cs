using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kontur.ImageTransformer.ImageFilters;
using Nancy;
using SixLabors.ImageSharp;

namespace Kontur.ImageTransformer
{
    using AsyncHandler = Func<dynamic, CancellationToken, Task<dynamic>>;
    using FilterFactory = Func<dynamic, ImageFilter>;
    
    public class RequestHandler : NancyModule
    {
        private static readonly Dictionary<string, FilterFactory> Factories = new Dictionary<string, FilterFactory>
        {
            {"threshold", d => new Threshold(new ThresholdParameters(d.x, d.y, d.w, d.h, d.param))},
            {"grayscale", d => new Grayscale(new FilterParameters(d.x, d.y, d.w, d.h))},
            {"sepia", d => new Sepia(new FilterParameters(d.x, d.y, d.w, d.h))}
        };
        
        public RequestHandler() : base("/process")
        {
            Post[$"/{UrlPatterns.GrayscaleFilter}/{UrlPatterns.Coordinates}", runAsync: true]
                = Post[$"/{UrlPatterns.SepiaFilter}/{UrlPatterns.Coordinates}", runAsync: true]
                = Post[$"/{UrlPatterns.ThresholdFilter}/{UrlPatterns.Coordinates}", runAsync: true]
                = ReturnBadRequestOnError(ProcessRequest);
        }

        private async Task<dynamic> ProcessRequest(dynamic parameters, CancellationToken ctx)
        {
            if (Request.Files.Count() != 1) 
                return HttpStatusCode.BadRequest;

            var file = await Task.Run(() => Request.Files.First(), ctx);
            var image = await Task.Run(() => Image.Load(file.Value), ctx);
            var filter = (ImageFilter)Factories[parameters.filter](parameters);
            await Task.Run(() => filter.PerformFilter(image), ctx);

            return new Response
            {
                ContentType = "image/png",
                Contents = stream =>
                {
                    using (var writer = new BinaryWriter(stream))
                        writer.Write(image.SavePixelData());
                }
            };

        }

        private static AsyncHandler ReturnBadRequestOnError(AsyncHandler handler)
        {
            return async (parameters, ctx) =>
            {
                try
                {
                    return await handler(parameters, ctx);
                }
                catch
                {
                    return HttpStatusCode.BadRequest;
                }
            };
        }
    }
}
