using GasMeter.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasMeter.ImageHandling
{
    public interface IImageWriter
    {
        Task<Guid> UploadImage(IFormFile file, ICapturedImageRepository repository);
    }
}
