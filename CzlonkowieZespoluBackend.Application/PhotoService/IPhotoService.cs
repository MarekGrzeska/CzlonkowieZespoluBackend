using Microsoft.AspNetCore.Http;

namespace CzlonkowieZespoluBackend.Application.PhotoService
{
    public interface IPhotoService
    {
        Task<string> SavePhoto(IFormFile photo);
    }
}
