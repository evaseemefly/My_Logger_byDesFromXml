using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Redis
{
    public class StringRedisHelper:RedisManager
    {
        public static bool Set(string key,string value)
        {
            return DbContext.StringSet(key, value);
            
        }

        public static bool Set(string key,string value)
        {
            return DbContext.StringSet(key, value, new TimeSpan() { });
        }

        public static string Get(string key)
        {
            if(Exist(key))
            {
                return DbContext.StringGet(key);
            }
            else
            {
               return string.Empty;
            }
        }

        public static bool Exist(string key)
        {
            return DbContext.KeyExists(key);
        }
    }
}
