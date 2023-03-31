using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

[Authorize]
public class AccountController : Controller
{
    private UserManager<AppUser> userManager;
    private SignInManager<AppUser> signInManager;

    public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr)
    {
        userManager = userMgr;
        signInManager = signInMgr;
    }
    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        // return url remembers the user's original request
        ViewBag.returnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLogin details, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            AppUser user = await userManager.FindByEmailAsync(details.Email);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl ?? "/");
                }
            }
            ModelState.AddModelError(nameof(UserLogin.Email), "Invalid user or password");
        }
        return View(details);
    }

    [AllowAnonymous]
    public ViewResult AccessDenied() => View();

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
