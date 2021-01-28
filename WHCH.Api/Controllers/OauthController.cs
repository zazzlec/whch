/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using WHCH.Api.Entities;
using WHCH.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using WHCH.Api.Auth;
using static WHCH.Api.Entities.Enums.CommonEnum;
using WHCH.Api.Utils;
using System;

namespace WHCH.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OauthController : ControllerBase
    {
        private readonly AppAuthenticationSettings _appSettings;
        private readonly WHCHDbContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSettings"></param>
        public OauthController(IOptions<AppAuthenticationSettings> appSettings, WHCHDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Auth(string username, string password)
        {
            var response = ResponseModelFactory.CreateInstance;
            DncUser user;
            try
            {
                using (_dbContext)
                {
                    user = _dbContext.DncUser.FirstOrDefault(x => x.LoginName == username.Trim());
                    if (user == null || user.IsDeleted == IsDeleted.Yes)
                    {
                        response.SetFailed("用户不存在");
                        return Ok(response);
                    }
                  //  Console.WriteLine("1:"+password);
                    password = CryptoAES.DecryptByAES(password.Trim(), "11111111111111111111111111111112");
                   // Console.WriteLine("2:" + password);
                    password = CryptoClass.RSAEncryption(password.Trim());
                    //Console.WriteLine("3:" + password);
                   // Console.WriteLine("5:" + user.Password);
                    if (user.Password != password.Trim())
                    {
                        response.SetFailed("密码不正确");
                        return Ok(response);
                    }
                    if (user.IsLocked == IsLocked.Locked)
                    {
                        response.SetFailed("账号已被锁定");
                        return Ok(response);
                    }
                    if (user.Status == UserStatus.Forbidden)
                    {
                        response.SetFailed("账号已被禁用");
                        return Ok(response);
                    }
                }
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("guid",user.Guid.ToString()),
                    new Claim("avatar",""),
                    new Claim("displayName",user.DisplayName),
                    new Claim("loginName",user.LoginName),
                    new Claim("emailAddress",""),
                    new Claim("guid",user.Guid.ToString()),
                    new Claim("userType",((int)user.UserType).ToString())
                    });
                var token = JwtBearerAuthenticationExtension.GetJwtAccessToken(_appSettings, claimsIdentity);

                response.SetData(token);
                return Ok(response);
            }
            catch (System.Exception ee)
            {

                response.SetError(ee.Message);
                return Ok(response);
            }
            
        }
    }
}