using ECommerce.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        //On the fly image delivery
        public async Task<IActionResult> Index(string url, int w = 0, int h = 0)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                                           url);

            if (System.IO.File.Exists(filePath))
            {
                SixLabors.ImageSharp.Image sourceImage = SixLabors.ImageSharp.Image.Load(filePath);

                if (sourceImage != null)
                {
                    try
                    {
                        var imageSize = DynamicSize.GetImageSize(sourceImage.Width, sourceImage.Height, w, h);

                        sourceImage.Mutate(x => x.Resize((int)imageSize.width, (int)imageSize.height));

                        Stream outputStream = new MemoryStream();

                        sourceImage.Save(outputStream, new JpegEncoder());
                        outputStream.Seek(0, SeekOrigin.Begin);

                        return this.File(outputStream, "image/jpg");
                    }
                    catch (Exception e)
                    {
                        //throw;
                    }
                }
            }

            return this.NotFound();
        }

        //Delete Image
        [HttpPost]
        public async Task<dynamic> DeleteImage(string path)
        {
            if (path != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
                var returnFilePath = "" + path;
                if (System.IO.File.Exists(filePath))
                {
                    FileInfo file = new FileInfo(filePath);
                    file.Delete();
                    return new { Code = 200, DeletedImage = returnFilePath, Message = "Success" };
                }

                return new { Code = 500, TriedToDelete = returnFilePath, Message = "Failed" };
            }

            return new { Code = 505, Message = "Failed! Bad Parameter Format" };
        }

        // Upload Image
        [HttpPost]
        public async Task<dynamic> ImageUploader(IFormFile file)
        {

            var folderName = "Files";
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                                           folderName);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            var paramFileName = file.FileName;
            if (paramFileName.Contains(","))
            {
                paramFileName = paramFileName.Replace(",", "_");
            }

            var fileName = paramFileName;

            filePath = Path.Combine(filePath, fileName);

            var returnFilePath = $"{folderName}\\{fileName}";

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                try
                {
                    file.CopyTo(fs);

                }
                catch (Exception e)
                {
                    return new { Code = 500, Path = returnFilePath, Message = e.Message };
                }
            }

            return new { Code = 200, Path = returnFilePath, Message = "Success" };
        }
    }
}
