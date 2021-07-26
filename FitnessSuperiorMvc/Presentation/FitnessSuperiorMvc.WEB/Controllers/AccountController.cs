using System;
using System.Threading.Tasks;
using AutoMapper;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.WEB.ViewModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Staff;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Users;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.People.Users;



namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly FitnessAppContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(FitnessAppContext context, IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            var user = new IdentityUser(model.Login){Email = model.Email, PhoneNumber = model.Phone};
            var result = await _userManager.CreateAsync(user, model.Password);

                
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _userManager.AddToRoleAsync(user, model.Role);
                return RedirectToAction("RegisterByRole", new {model.Role,model.Name,model.Surname,model.BirthDate});
            }
            ModelState.AddModelError(string.Empty, "Invalid register attempt.");
            return View(model);

        }
        [AllowAnonymous]
        public async Task<IActionResult> RegisterByRole(string role, string name, string surname, DateTime birthDate)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            switch (role)
            {
                case "User":
                {
                    UserDto dto = _mapper.Map<UserDto>(
                        new User(name, surname, birthDate)
                        );
                    dto.IdentityId = user.Id;
                    await _context.UsersDto.AddAsync(dto);
                    break;
                }
                case "Trainer":
                {
                    TrainerDto dto = _mapper.Map<TrainerDto>(
                        new Trainer(name, surname, birthDate)
                        );
                    dto.IdentityId = user.Id;
                    await _context.Trainers.AddAsync(dto);
                    break;
                }
                case "Nutritionist":
                {
                    Nutritionist nutritionist = (
                        new Nutritionist(name, surname, birthDate)
                        );
                    NutritionistDto dto = _mapper.Map<NutritionistDto>(nutritionist);
                    dto.IdentityId = user.Id;
                    await _context.Nutritionists.AddAsync(dto);
                    break;
                }
                case "Admin":
                {

                
                    Manager manager = (
                        new Manager(name, surname, birthDate) { Position = "Admin" }
                    );
                    ManagerDto dto = _mapper.Map<ManagerDto>(manager);
                    dto.IdentityId = user.Id;
                    await _context.Managers.AddAsync(dto);
                    break;
                }
                default: return NotFound("Role does not exist");
                
            }
            await _context.SaveChangesAsync();
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Users()
        {

            UsersViewModel model = new UsersViewModel() { UserNames = _userManager.Users.Select(p => p.UserName).ToList() };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
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

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
