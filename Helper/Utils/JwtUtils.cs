using JWT_TokenBased.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JWT_TokenBased.Helper.Utils
{
    public class JwtUtils
    {
        static string secret = "3hO4Lash4CzZfk0Ga6yQhd48208RGTAu";

        public static string GenerateJwtToken(UserModel user)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);


            // token class
            List<Claim> claims = new List<Claim>
            {
                new Claim("user_id",user.id.ToString()),
                new Claim("username",user.username),
            };  
          
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(jwtToken);
        }

        public static bool ValidateJwtToken(string jwt)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(secret);

                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                tokenHandler.ValidateToken(jwt, validationParameters, out SecurityToken validatedToken);
                JwtSecurityToken validatedJWT = (JwtSecurityToken)validatedToken;

                // get claims 
                long user_id = long.Parse(validatedJWT.Claims.First(claim => claim.Type == "user_id").Value);

                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    UserModel? user = dbContext.User.FirstOrDefault(u => u.id == user_id);
                    if (user == null)
                    {
                        return false;
                    }
                    else
                    {
                        // check is the given token s the last issuedtoken to the user
                        LoginDetailModel loginDetail = dbContext.LoginDetail.Where(id => id.user_id == user_id).First();

                        //login detail must available
                        if (loginDetail.token != jwt)
                        {
                            return false;
                        }
                        else
                        {
                            // token is valid and latest token
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
