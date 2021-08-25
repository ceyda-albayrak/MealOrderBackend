using System;
using System.Collections.Generic;
using System.Text;
using Core.Concretes.Entities;
using Entities;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
