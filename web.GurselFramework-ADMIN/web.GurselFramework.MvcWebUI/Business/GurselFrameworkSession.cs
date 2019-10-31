using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.GurselFramework.Business.HttpService.Concrete.Models;
using web.GurselFramework.Core.NoSql.Redis;
using web.GurselFramework.Core.NoSql.Redis.Model;
using web.GurselFramework.Framework.Constant;
using web.GurselFramework.Framework.Helper;

namespace web.GurselFramework.MvcWebUI.Business
{
    public class GurselFrameworkSession
    {
        public static int UserId
        {
            get
            {
                var userIdCookie = CookieHelper.Get(CookieConstants.USER_ID_COOKIE);
                if (userIdCookie.IsNotNull())
                {
                    var userId = CryptoHelper.Decrypt(userIdCookie).ToInt();
                    if (userId > decimal.Zero)
                        return userId;
                    else
                        return (int)decimal.MinusOne;
                }

                return (int)decimal.MinusOne;
            }
        }

        public static UserInformation UserOnRedis
        {
            get
            {
                var user = new UserInformation();
                if (UserId > decimal.Zero)
                {
                    var redisKey = $"*UserCurrentSessionæ{UserId}æ*";
                    var tokenModel = new RedisHelper().Get<TokenModel>(redisKey);
                    if (tokenModel.User.IsNotNull())
                    {
                        var userInformation = tokenModel.User.FromJson<UserInformation>();
                        if (userInformation.UserId > decimal.Zero)
                        {
                            user = userInformation;
                        }
                    }
                }

                return user;
            }
        }

        public static UserInformation User
        {
            get
            {
                try
                {
                    var userIdCookie = CookieHelper.Get(CookieConstants.USER_ID_COOKIE);
                    var cookieUserId = CryptoHelper.Decrypt(userIdCookie).ToInt();
                    if (userIdCookie.IsNotNull() && cookieUserId > 0)
                    {
                        var rememberMe = CookieHelper.Get(CookieConstants.USER_REMEMBER_ME).ToInt();
                        var redisKey = $"*UserCurrentSessionæ{cookieUserId}æ*";
                        var user = new RedisHelper().Get<TokenModelTemplate>(redisKey);
                        if (user != null && user.AccessToken.IsNotNull())
                        {
                            var userInformation = user.User.FromJson<UserInformation>();
                            if (userInformation != null && userInformation.UserId > decimal.Zero)
                            {
                                var password = CryptoHelper.Decrypt(userInformation.Password);

                                CookieHelper.Set(CookieConstants.USER_ID_COOKIE, CryptoHelper.Encrypt(cookieUserId.ConvertToString()));
                                CookieHelper.Set(CookieConstants.USER_REMEMBER_ME, rememberMe.ConvertToString());

                                var data = new RedisHelper().Get<UserInformation>(redisKey);

                                new RedisHelper().RedisExistRemoveSet(new RedisRequestTemplate { RedisKey = "*" + redisKey + "*", RedisValue = user });

                                return data;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                 
                }

                return new UserInformation();
            }

            set
            {

            }
        }
    }
}