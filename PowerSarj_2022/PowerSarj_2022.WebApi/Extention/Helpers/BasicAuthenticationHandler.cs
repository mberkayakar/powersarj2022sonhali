using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete;

namespace WebApi.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        IConfiguration _configuraiton;
        public BasicAuthenticationHandler(
            
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IConfiguration configuration
            
            ) : base(options, logger, encoder, clock)
        {
            _configuraiton = configuration;
        }



        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authentication");   
            }
            try
            {
                var autHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialsByes = Convert.FromBase64String(autHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsByes).Split(':');

                var username = credentials[0];
                var password = _configuraiton["password"].ToString();

                if (  username == credentials[0] && password == credentials[1])
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name ,credentials[0])
                    };

                    var identity = new ClaimsIdentity(claims , Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);

                }
                else
                {
                    return AuthenticateResult.Fail("Header uyumsuz");

                }
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Header uyumsuz");
            }
        }


        #region Eski Kodlar

        //private readonly IAdminService _userService;

        //public BasicAuthenticationHandler(
        //    IOptionsMonitor<AuthenticationSchemeOptions> options,
        //    ILoggerFactory logger,
        //    UrlEncoder encoder,
        //    ISystemClock clock,
        //    IAdminService userService)
        //    : base(options, logger, encoder, clock)
        //{
        //    _userService = userService;
        //}

        //protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        //{
        //    //// skip authentication if endpoint has [AllowAnonymous] attribute
        //    var endpoint = Context.GetEndpoint();
        //    if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        //        return AuthenticateResult.NoResult();

        //    if (!Request.Headers.ContainsKey("Authorization"))
        //        return AuthenticateResult.Fail("Missing Authorization Header");

        //    Admin user = null;
        //    try
        //    {
        //        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        //        var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
        //        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
        //        var username = credentials[0];
        //        var password = credentials[1];
        //        user = await _userService.Authenticate(username, password);
        //    }
        //    catch
        //    {
        //        return AuthenticateResult.Fail("Invalid Authorization Header");
        //    }

        //    if (user == null)
        //        return AuthenticateResult.Fail("Invalid Username or Password");

        //    var claims = new[] {
        //        new Claim(ClaimTypes.NameIdentifier, user._id.ToString()),
        //        new Claim(ClaimTypes.Name, user.UserName),
        //    };
        //    var identity = new ClaimsIdentity(claims, Scheme.Name);
        //    var principal = new ClaimsPrincipal(identity);
        //    var ticket = new AuthenticationTicket(principal, Scheme.Name);

        //    return AuthenticateResult.Success(ticket);
        //}

        #endregion

    }
}