using GasMeter.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasMeter.ImageHandling
{
    public interface IImageHandler
    {
        Task<Guid> UploadImage(IFormFile file, ICapturedImageRepository repository);
    }
}
