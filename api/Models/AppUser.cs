using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

#region -- AppUser JWT
// Inherit From IdentityUser ☑
// Inherit Our DBContext from IdentityDbContext with the new AppUser Obj -- ApplicationContext File ☑
// Add Identity for the Model and the Identity Roles .. then add the restrictions -- Program File ☑
// Add EntityFrameworkStores add ApplicationDBContext  -- Program File ☑
// Add Authentication and the defaults options-- Program File ☑
// Add JWTBearer and the TokenValidationParameters -- Program File ☑
// Add JWT:Issuer,Audience,SigningKey -- appSettings File ☑
// Add UseAuthentication, UseAuthorization -- Program File ☑
// dotnet ef migrations add Identity , dotnet ef database update -- Migrations Commands ☑
// 
#endregion

namespace api.Models
{
    public class AppUser :IdentityUser
    {
        
    }
}