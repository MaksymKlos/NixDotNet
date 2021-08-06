using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.People.Users;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.WEB.ViewModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        private readonly UserService _userService;
        private readonly TrainerService _trainerService;
        private readonly NutritionistService _nutritionistService;
        private readonly ManagerService _managerService;



        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            UserService userService,
            TrainerService trainerService,
            NutritionistService nutritionistService,
            ManagerService managerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
            _trainerService = trainerService;
            _nutritionistService = nutritionistService;
            _managerService = managerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new IdentityUser(model.Login) {Email = model.Email, PhoneNumber = model.Phone};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _userManager.AddToRoleAsync(user, model.Role);
                return RedirectToAction("RegisterByRole", new {model.Role, model.Name, model.Surname, model.BirthDate});
            }

            ModelState.AddModelError(string.Empty, "Invalid register attempt.");
            return View(model);

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RegisterByRole(string role, string name, string surname, DateTime birthDate)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            string userId = user.Id;
            switch (role)
            {
                case "User":
                {
                    var userDto = new UserDto(name, surname, birthDate)
                    {
                        IdentityId = userId
                    };
                    await Task.Run(()=>_userService.Create(_mapper.Map<User>(userDto)));
                    break;
                }
                case "Trainer":
                {
                    var trainerDto = new TrainerDto(name, surname, birthDate)
                    {
                        IdentityId = userId
                    };
                    await Task.Run(() => _trainerService.Create(_mapper.Map<Trainer>(trainerDto)));
                    break;
                }
                case "Nutritionist":
                {
                    var nutritionistDto = new NutritionistDto(name, surname, birthDate)
                    {
                        IdentityId = userId
                    };
                    await Task.Run(() => _nutritionistService.Create(_mapper.Map<Nutritionist>(nutritionistDto)));
                    break;
                }
                case "Admin":
                {
                    var managerDto = new ManagerDto(name, surname, birthDate)
                    {
                        Position = role,
                        IdentityId = userId
                    };
                    await Task.Run(() => _managerService.Create(_mapper.Map<Manager>(managerDto)));
                    break;
                }
                default: return NotFound("Role does not exist");
                
            }
            return RedirectToAction("Logout");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.Confirm, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt. Check your email and password and try again");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (!ModelState.IsValid) return View(createRoleViewModel);
            var result = await _roleManager.CreateAsync(new IdentityRole(createRoleViewModel.Role));
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid create role.");
            return View(createRoleViewModel);

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {

            UsersViewModel model = new UsersViewModel() { UserNames = _userManager.Users.Select(p => p.UserName).ToList() };
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignUserRole(string userName)
        {
            AssignUserRoleViewModel model = new AssignUserRoleViewModel();
            var user = _userManager.Users.SingleOrDefault(p => p.UserName == userName);
            if (user == null)
            {
                return NotFound();
            }

            foreach (var role in _roleManager.Roles)
            {
                model.UserRoles.Add(new UserRoleViewModel()
                {
                    RoleName = role.Name,
                    IsAssigned = await _userManager.IsInRoleAsync(user, role.Name)
                });
            }

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignUserRole(AssignUserRoleViewModel model)
        {
            var user = _userManager.Users.SingleOrDefault(p => p.UserName == model.UserName);
            foreach (var userRoleViewModel in model.UserRoles)
            {
                if (await _userManager.IsInRoleAsync(user, userRoleViewModel.RoleName))
                {
                    await _userManager.RemoveFromRoleAsync(user, userRoleViewModel.RoleName);
                }

                if (userRoleViewModel.IsAssigned)
                {
                    var result = await _userManager.AddToRoleAsync(user, userRoleViewModel.RoleName);
                }
            }

            return RedirectToAction("Users");
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            return View(user);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
