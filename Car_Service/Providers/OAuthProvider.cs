using Car_Service.BLL.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;

namespace Car_Service.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _db;
        public OAuthProvider(IUserService db)
        {
            _db = db;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var claims = await _db.Authenticate(context.UserName, context.Password);
            if (claims != null)
            {
                context.Validated(claims);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
        }
    }
}