// VersionController.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class VersionController : Controller
{
    [HttpGet]
    public IActionResult SelectVersion(string version)
    {
        // Сохраняем выбранную версию в сессии
        HttpContext.Session.SetString("SelectedVersion", version);
        return RedirectToAction("Index", "Home"); // Перенаправление на главную страницу
    }
}
