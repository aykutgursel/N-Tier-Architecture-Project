using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using web.GurselFramework.Core.Configuration;
using web.GurselFramework.Core.NoSql.Redis.Model;
using web.GurselFramework.Framework.Helper;

namespace web.GurselFramework.Core.NoSql.Redis
{
    public class RedisHelper
    {
        private static IDatabase _db;
        private static readonly string host = Config.RedisHost();
        private static readonly int port = Config.RedisPort();
        private static readonly string password = Config.RedisPassword();

        public RedisHelper(bool operation = false)
        {
            if (operation)
            {
                CreateRedisDB();
            }
        }

        private static IDatabase CreateRedisDB()
        {
            if (null == _db)
            {
                ConfigurationOptions option = new ConfigurationOptions();
                option.AbortOnConnectFail = false;
                option.ResponseTimeout = 30;
                option.Ssl = false;
                option.EndPoints.Add(host, port);
                option.Password = password;

                var connect = ConnectionMultiplexer.Connect(option);
                _db = connect.GetDatabase();
            }

            return _db;
        }

        public void Set<T>(string key, T data, int expireDay = 360)
        {
            var expiresIn = DateTime.Now.AddDays(expireDay);
            var jsonData = data.ToJson();
            _db.SetAdd(key, jsonData);
            _db.KeyExpire(key, expiresIn);
        }

        public void SetAll(Dictionary<string, object> data, int expireDay = 360)
        {
            if (data != null && data.Any())
            {
                var expiresIn = DateTime.Now.AddDays(expireDay);

                foreach (var item in data)
                {
                    var jsonData = item.Value.ToJson();
                    _db.SetAdd(item.Key, jsonData);
                    _db.KeyExpire(item.Key, expiresIn);
                }
            }
        }

        public T Get<T>(string key)
        {
            var value = _db.SetMembers(key);
            if (value.Length == 0)
            {
                return default(T);
            }

            var data = value.LastOrDefault();
            var data2 = data.ConvertToString();
            if (data2.IsNotNull())
            {
                return data2.FromJson<T>();
            }

            return default(T);
        }

        public void Remove(string key)
        {
            _db.KeyDelete(key);
        }

        public void RemoveAll(string key)
        {
            var server = _db.Multiplexer.GetServer(host, port);
            var keys = server.Keys(pattern: key).ToList();
            if (keys.Any())
            {
                keys.ForEach(item =>
                {
                    _db.KeyDelete(item);
                });
            }
        }

        public bool Exist(string key)
        {
            var server = _db.Multiplexer.GetServer(host, port);
            return server.Keys(pattern: key).Any();
        }

        public bool RedisExistRemoveSet(RedisRequestTemplate template)
        {
            try
            {
                if (Exist(template.RedisKey))
                    Remove(template.RedisKey);

                Set(template.RedisKey, template.RedisValue);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public R RedisGet<R>(RedisRequestTemplate template)
        {
            return Get<R>(template.RedisKey);
        }

    }
}