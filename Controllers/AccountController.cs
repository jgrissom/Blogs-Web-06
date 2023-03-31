using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AccountController : Controller
{
    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        // return url remembers the user's original request
        ViewBag.returnUrl = returnUrl;
        return View();
    }
}
