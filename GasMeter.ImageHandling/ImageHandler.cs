using GasMeter.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasMeter.ImageHandling
{
    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<Guid> UploadImage(IFormFile file, ICapturedImageRepository repository)
        {
            var result = await _imageWriter.UploadImage(file, repository);
            return result;
        }
    }
}
