using System.Drawing;
using System.Threading.Tasks;

namespace JevKrayPersonalSite.Services.ServiceInterfaces
{
    public interface ICaptchaService
    {
        Task<bool> CheckCaptchaAsync(string captcha);
        Task<(string, Bitmap)> CreateCaptchaAsync();
    }
}
