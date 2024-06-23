using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneSistemiApi.Application.DTOs.Configuration;

namespace KutuphaneSistemiApi.Application.Abstractions.Services
{
    public interface IAuthService
    {
        List<Menu> GetAuthorizeDefinitonEndpoints(Type assemblyType);
    }
}
