using Microsoft.AspNetCore.Http;

namespace CzlonkowieZespoluBackend.Application.PhotoService
{
    public class PhotoService : IPhotoService
    {
        public async Task<string> SavePhoto(IFormFile photo)
        {
            if (photo != null && photo.Length != 0)
            {
                using (var ms = new MemoryStream()) 
                {
                    photo.CopyTo(ms);
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                    var filePath = Path.Combine(uploadFolder, fileName);
                    await File.WriteAllBytesAsync(filePath, ms.ToArray());
                    return fileName;
                }
            }
            return "";
        }
    }
}
