using GasMeter.DataModels;
using GasMeter.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GasMeter.ImageHandling
{
    public class ImageWriter : IImageWriter
    {
        public async Task<Guid> UploadImage(IFormFile file, ICapturedImageRepository repository)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file, repository);
            }
            return Guid.Empty;
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<Guid> WriteFile(IFormFile file, ICapturedImageRepository repository)
        {
            try
            {
                CapturedImage image = new CapturedImage() {
                    Data = file.OpenReadStream().ReadToEnd(),
                    DateTaken = DateTime.Now
                };
                repository.Create(image);

                return image.Id;
            }
            catch (Exception e)
            {
            }
            return Guid.Empty;
        }
    }
}
