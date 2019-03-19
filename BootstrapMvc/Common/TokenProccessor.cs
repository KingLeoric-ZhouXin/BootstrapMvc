using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BootstrapMvc.UI.Common
{
    public class TokenProccessor<T>
    {
        //私钥  web.config中配置
        //"";
        private static string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <param name="payload">不敏感的用户数据</param>
        /// <returns></returns>
        public static string SetJwtEncode(T t)
        {

            Dictionary<string, object> payload = EntityToDictionary(t);

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }

        /// <summary>
        /// 根据jwtToken  获取实体
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        public static Base_UserInfo GetJwtDecode(string token)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            var userInfo = decoder.DecodeToObject<Base_UserInfo>(token, secret, verify: true);//token为之前生成的字符串
            return userInfo;
        }

        public static Dictionary<string, object> EntityToDictionary(T t)
        {
            Type type = t.GetType();
            PropertyInfo[] items = type.GetProperties();
            Dictionary<string, object> dictList = new Dictionary<string, object>();

            foreach (var item in items)
            {
                if (item.GetValue(type) != null)
                {
                    dictList.Add(item.Name, item.GetValue(type));
                }
            }

            return dictList;
        }
    }
}