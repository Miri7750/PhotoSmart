

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon.S3;
using Amazon.S3.Model;

namespace PhotoSmart.Api.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;

        public UploadController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpGet("presigned-url")]
        public async Task<IActionResult> GetPresignedUrl([FromQuery] string fileName)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = "photo-smart-app",
                Key = fileName,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(5),
                ContentType = "image/jpeg"
            };

            string url = _s3Client.GetPreSignedURL(request);
            Console.WriteLine($"Generated Presigned URL: {url}"); // הוסף שורה זו לדיבוג

            return Ok(new { url });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // בדיקת סוג הקובץ
                var allowedTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif" };
                if (!allowedTypes.Contains(imageFile.ContentType))
                {
                    return Content("Invalid file type.");
                }

                // שמירת הקובץ בשרת
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // עיבוד נוסף (למשל, שינוי גודל התמונה)
                // כאן אפשר להוסיף קוד לשינוי גודל התמונה אם נדרש

                return Content("Image uploaded and processed successfully!");
            }


            return Content("No image uploaded.");
        }
      

    }
}





