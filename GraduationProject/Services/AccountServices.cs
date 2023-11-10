//using GraduationProject.DTO;
//using GraduationProject.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace GraduationProject.Services
//{
//    public class AccountServices
//    {
//        private readonly UserManager<User> usermanger;
//        private readonly IConfiguration configuration;
//        Context context = new Context();

//        //public AccountController(UserManager<User> usermanger, IConfiguration configuration)
//        //{
//        //    this.usermanger = usermanger;
//        //    this.configuration = configuration;
//        //}
//        ////create account ,,, registration
//        [HttpPost("register")]//api/account/register
//        public async void Registration(RegisterUser registerUser)
//        {
//            User user = new User();
//            user.Email = registerUser.Email;
//            user.UserName = registerUser.UserName;
//            user.FirstName = registerUser.FirstName;
//            user.LastName = registerUser.LastName;
//            user.Phone = registerUser.Phone;
//            // user.Picture = registerUser.Picture;
//            user.Street = registerUser.Street;
//            user.City = registerUser.City;
//            await usermanger.CreateAsync(user, registerUser.Password);        
//        }
//}

//        //login check account valid
//        //[Authorize]
//        [HttpPost("login")] //api/Account/Login
//        public async Task LoginAsync(Login userDto)
//        {

//            //  var user = _dbContext.Users.Include(u=>u.Role).FirstOrDefault(u => u.Email == dto.Email);
//            // if (user is null) throw new BadRequestException("Invalid username or password");
//               var user = context.Users.FirstOrDefault(u => u.UserName == userDto.UserName);
//                if (user != null)
//                {
//                    bool found = await usermanger.CheckPasswordAsync(user, userDto.Password);
//                    if (found)
//                    {
//                        //claims token
//                        var claims = new List<Claim>();
//                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
//                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
//                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

//                        //get role
//                        var roles = await usermanger.GetRolesAsync(user);
//                        foreach (var item in roles)
//                        {
//                            claims.Add(new Claim(ClaimTypes.Role, item));

//                        }
//                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
//                        //    signingCredentials 
//                        SigningCredentials signing = new SigningCredentials(securityKey,
//                        SecurityAlgorithms.HmacSha256
//                        );


//                        JwtSecurityToken MyToken = new JwtSecurityToken(
//                        issuer: configuration["JWT:ValidIssuer"],//url for web api << provider
//                        audience: configuration["JWT:ValidAudiance"], // url consumer << angular
//                        claims: claims,
//                        expires: DateTime.Now.AddDays(30),
//                        signingCredentials: signing
//                        );
                     
//                    }
//                }

             
//            }
 
//        }
//        [HttpPost("ForgetPassword")]
//        public async Task<IActionResult> ForgetPassword(ForgetPassword _user)
//        {
//            User user = await usermanger.FindByNameAsync(_user.UserName);
//            var token = await usermanger.GeneratePasswordResetTokenAsync(user);
//            if (user != null)
//            {

//                var result = await usermanger.ResetPasswordAsync(user, token, _user.ChangePass);
//                //ChangePasswordAsync(user, user.PasswordHash, NewPassword);
//                //  GeneratePasswordResetTokenAsync(user);
//                if (result.Succeeded)
//                {

//                    return Ok("New PassWord Add Done");
//                }
//                else
//                {
//                    var Errors = string.Empty;
//                    foreach (var error in result.Errors)
//                    {
//                        Errors += $"{error.Description}  +  ";
//                    }
//                    return BadRequest(Errors);
//                }


//            }
//            return Unauthorized();
//        }
//        [HttpPost("changePassword")]
//        public async Task<IActionResult> changePassword(ChangePassword _user)
//        {
//            User user = await usermanger.FindByNameAsync(_user.UserName);
//            if (user != null)
//            {

//                var result = await usermanger.ChangePasswordAsync(user, _user.OldPassword, _user.NewPassword);
//                //ChangePasswordAsync(user, user.PasswordHash, NewPassword);
//                //  GeneratePasswordResetTokenAsync(user);
//                if (result.Succeeded)
//                {

//                    return Ok("Password  Change Succeeded");
//                }
//                else
//                {
//                    var Errors = string.Empty;
//                    foreach (var error in result.Errors)
//                    {
//                        Errors += $"{error.Description}  +  ";
//                    }
//                    return BadRequest(Errors);
//                }


//            }
//            return Unauthorized();
//        }
//    }
//}
