using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public UserController(UserManager<User> _userManager,
			SignInManager<User> _signInManager)
		{
			userManager = _userManager;
			signInManager = _signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("All", "Movies");
			}

			return View(new RegisterViewModel());
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(registerViewModel);
			}

			var user = new User()
			{
				Email = registerViewModel.Email,
				UserName = registerViewModel.Username
			};

			var result = await userManager.CreateAsync(user, registerViewModel.Password);

			if (result.Succeeded)
			{
				// await signInManager.SignInAsync(user, isPersistent: false);

				return RedirectToAction("Login", "User");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}

			return View(registerViewModel);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("All", "Movies");
			}

			return View(new LoginViewModel());
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginViewModel);
			}
			var user = await userManager.FindByNameAsync(loginViewModel.Username);

			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

				if (result.Succeeded)
				{
					return RedirectToAction("All", "Movies");
				}
			}

			ModelState.AddModelError("", "Invalid Input");

			return View(loginViewModel);
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
