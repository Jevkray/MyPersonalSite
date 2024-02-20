using JevKrayPersonalSite.DAL;
using JevKrayPersonalSite.Models;
using JevKrayPersonalSite.PrivateServices.MailSender;
using JevKrayPersonalSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net.Mail;

namespace JevKrayPersonalSite.Controllers
{
    public class HomeNewController : Controller
    {
        private readonly JevkSiteDbContext _dbContext;
        private readonly ILogger<HomeNewController> _logger;

        public HomeNewController(ILogger<HomeNewController> logger, JevkSiteDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCapcha()
        {
            var captchaResult = await CapchaGenerator.CreateCapchaAsync(); // Ваш метод для создания капчи

            // Преобразование изображения в массив байтов в формате PNG
            byte[] imageBytes;
            using (var ms = new MemoryStream())
            {
                captchaResult.Item2.Save(ms, ImageFormat.Png);
                imageBytes = ms.ToArray();
            }

            string capchaCache = CacherService.CalculateMD5Hash(captchaResult.Item1);
            string sessionId = Guid.NewGuid().ToString();

            CapchaSessionModel capchaSessionModel = new CapchaSessionModel()
            {
                SessionId = sessionId,
                CapchaCache = capchaCache,
                CreatedAt = DateTime.Now,
            };

            _dbContext.Add(capchaSessionModel);
            await _dbContext.SaveChangesAsync();

            Response.Cookies.Append("CapchaSessionId", sessionId, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return File(imageBytes, "image/png");
        }

        [HttpPost]
        public async Task<bool> CheckCapcha(string capcha)
        {
            if (Request.Cookies["CapchaSessionId"] != "")
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                string sessionId = Request.Cookies["CapchaSessionId"];
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                bool isValidCapcha = await IsValidCapcha(capcha.ToLower(), sessionId);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

                Response.Cookies.Delete("CapchaSessionId");

                var capchaSession = _dbContext.CapchaSessions.FirstOrDefault(c => c.SessionId == sessionId);

                if (capchaSession != null)
                {
                    _dbContext.CapchaSessions.Remove(capchaSession);
                    await _dbContext.SaveChangesAsync();
                }
                return isValidCapcha;
            }
            else
            {
                return false;
            }
        }

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        public async Task<bool> IsValidCapcha(string capcha, string sessionId)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        {
            var capchaSessionModel = _dbContext.CapchaSessions.FirstOrDefault(c => c.SessionId == sessionId);

            if (capchaSessionModel != null)
            {
                string inputCapchaHash = CacherService.CalculateMD5Hash(capcha);
                bool isValid = inputCapchaHash == capchaSessionModel.CapchaCache;

                return isValid;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult SendEmail(string Username, string Email, string Title, string Message)
        {
            try
            {
                MailMessage mail = CodeMail.CreatieMail(Username, Email, Title, Message);
                CodeMail.SendMail(mail);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}