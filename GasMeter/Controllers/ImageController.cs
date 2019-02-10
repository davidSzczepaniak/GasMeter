using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasMeter.ImageHandling;
using GasMeter.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasMeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageHandler imageHandler;
        private readonly ICapturedImageRepository repo;

        public ImageController(IImageHandler imageHandler, ICapturedImageRepository repository)
        {
            this.imageHandler = imageHandler;
            this.repo = repository;
        }

        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<Guid> UploadImage([FromForm]IFormFile file)
        {
            return await imageHandler.UploadImage(file, repo);
        }
    }
}