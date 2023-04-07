using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using MemberPlatformApi.Models;
using MemberPlatformCore.Models;
using MemberPlatformCore.Services;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Controller]
    public class AuthController : ControllerBase
    {
        private static List<Person> personList = new List<Person>();
        private readonly AppSettings _applicationSettings;
        private readonly HttpClient _httpClient;
        private readonly IPersonService _personService;


        public AuthController(IOptions<AppSettings> _applicationSettings, HttpClient httpClient, IPersonService personService)
        {
            this._applicationSettings = _applicationSettings.Value;
            _httpClient = httpClient;
            _personService = personService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] Person person)
        {
            //var user = UserList.Where(x => x.UserName == personApi.UserName).FirstOrDefault();

            //personList = await _personController.GetAllWithAddress();


            //if (user == null)
            //{
            //    return BadRequest("Username Or Password Was Invalid");
            //}

            //var match = CheckPassword(model.Password, user);

            //if (!match)
            //{
            //    return BadRequest("Username Or Password Was Invalid");
            //}

            //JWTGenerator(user);

            return Ok();

        }

        private dynamic JWTGenerator(Person person)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("EmailAddress", person.EmailAddress) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            SetJWT(encrypterToken);

            var refreshToken = GenerateRefreshToken();

            SetRefreshToken(refreshToken, person);

            return new { token = encrypterToken, username = person.EmailAddress };

        }

        private void SetJWT(string encrypterToken)
        {
            // This code sets a JSON Web Token(JWT) in a cookie named "X-Access-Token" in the response.
            // The JWT is passed to the method as the encrypterToken parameter.
            // The CookieOptions object specifies the settings for the cookie.
            // The Expires property sets the cookie expiration time to 15 minutes from the current time.
            // The HttpOnly property is set to true, which ensures that the cookie cannot be accessed via client - side scripts.
            // The Secure property is set to true, which ensures that the cookie is only sent over HTTPS.
            // The IsEssential property is set to true, which ensures that the cookie is sent even if the user has disabled cookies.
            // Finally, the SameSite property is set to None, which allows the cookie to be sent in cross - site requests.

             HttpContext.Response.Cookies.Append("X-Access-Token", encrypterToken,
                  new CookieOptions
                  {
                      Expires = DateTime.Now.AddMinutes(15),
                      HttpOnly = true,
                      Secure = true,
                      IsEssential = true,
                      SameSite = SameSiteMode.None
                  });
        }

        private RefreshToken GenerateRefreshToken()
        {
            // Create a RefreshToken object
            var refreshToken = new RefreshToken()
            {
                // Generate a random string
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                // Set the expiry date to 7 days
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;

        }

        //[HttpGet("RefreshToken")]
        //public async Task<ActionResult<string>> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["X-Refresh-Token"];

        //    var user = personList.Where(x => x.Token == refreshToken).FirstOrDefault();

        //    if (user == null || user.TokenExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token has expired");
        //    }

        //    JWTGenerator(user);

        //    return Ok();
        //}

        private void SetRefreshToken(RefreshToken refreshToken, Person person)
        {

            HttpContext.Response.Cookies.Append("X-Refresh-Token", refreshToken.Token,
                 new CookieOptions
                 {
                     Expires = refreshToken.Expires,
                     HttpOnly = true,
                     Secure = true,
                     IsEssential = true,
                     SameSite = SameSiteMode.None
                 });

            var HierPersoonUpdaten = 1;

            //personList.Where(x => x.UserName == person.UserName).First().Token = refreshToken.Token;
            //personList.Where(x => x.UserName == person.UserName).First().TokenCreated = refreshToken.Created;
            //personList.Where(x => x.UserName == person.UserName).First().TokenExpires = refreshToken.Expires;
        }

        //[HttpDelete("RevokeToken/{username}")]
        //public async Task<IActionResult> RevokeToken(string username)
        //{
        //    UserList.Where(x => x.UserName == username).First().Token = "";

        //    return Ok();
        //}


        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            // Create a Google Json web signature object.
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                // Link it to the GoogleClientId of our application
                Audience = new List<string> { this._applicationSettings.GoogleClientId }
            };

            // Contact the Google webservice and provide (1) the credential (received from the frontend) and
            // (2) the Google json web signature. Validate if the credentials match.
            // If successful, you receive an account back
            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

            // Get all the persons in our database.
            personList = await _personService.GetAllWithAddressAsync();

            // See if the google account is present in our database.
            var person = personList.Where(x => x.EmailAddress == payload.Email).FirstOrDefault();

            if (person != null)
            {
                var test = JWTGenerator(person);
                return Ok(test);
                //return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpPost("LoginWithFacebook")]
        //public async Task<IActionResult> LoginWithFacebook([FromBody] string credential)
        //{
        //    HttpResponseMessage debugTokenResponse = await _httpClient.GetAsync("https://graph.facebook.com/debug_token?input_token=" + credential + $"&access_token={this._applicationSettings.FacebookAppId}|{this._applicationSettings.FacebookSecret}");

        //    var stringThing = await debugTokenResponse.Content.ReadAsStringAsync();
        //    var userOBJK = JsonConvert.DeserializeObject<FBUser>(stringThing);

        //    if (userOBJK.Data.IsValid == false)
        //    {
        //        return Unauthorized();
        //    }

        //    HttpResponseMessage meResponse = await _httpClient.GetAsync("https://graph.facebook.com/me?fields=first_name,last_name,email,id&access_token=" + credential);
        //    var userContent = await meResponse.Content.ReadAsStringAsync();
        //    var userContentObj = JsonConvert.DeserializeObject<FBUserInfo>(userContent);

        //    var user = UserList.Where(x => x.UserName == userContentObj.Email).FirstOrDefault();

        //    if (user != null)
        //    {
        //        return Ok(JWTGenerator(user));
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //private bool CheckPassword(string password, User user)
        //{
        //    bool result;

        //    using (HMACSHA512? hmac = new HMACSHA512(user.PasswordSalt))
        //    {
        //        var compute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        result = compute.SequenceEqual(user.PasswordHash);
        //    }

        //    return result;
        //}

        //[HttpPost("Register")]
        //public IActionResult Register([FromBody] PersonApi personApi)
        //{
        //    var user = new User { UserName = personApi.UserName, Role = personApi.Role, BirthDay = personApi.BirthDay };

        //    if (model.ConfirmPassword == model.Password)
        //    {
        //        using (HMACSHA512? hmac = new HMACSHA512())
        //        {
        //            user.PasswordSalt = hmac.Key;
        //            user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Passwords Dont Match");
        //    }

        //    UserList.Add(user);

        //    return Ok(user);
        //}
    }
}
