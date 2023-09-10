using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormTest.Pages;

public class Login : PageModel
{
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            RedirectUri = Request.Host.Value
        };
        
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new(ClaimTypes.Email, "user@example.com"),
                        new(ClaimTypes.GivenName, "First Name"),
                        new(ClaimTypes.Surname, "Last Name")
                    }, CookieAuthenticationDefaults.AuthenticationScheme)),
            authProperties);
        
        return LocalRedirect("/");
    }
}