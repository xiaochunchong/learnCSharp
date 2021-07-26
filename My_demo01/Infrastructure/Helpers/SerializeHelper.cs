using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helpers
{
    /// <summary>
    /// 序列化类
    /// </summary>
    public  class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return Encoding.UTF8.GetBytes(jsonString);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] value)
        {
            if (value == null)
            {
                return default(T);
            }
            var jsonString = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /* Test测试
         * public static T Test<T>(string a) 
         {
             if (a!=null)
             {
               var bb= JsonConvert.DeserializeObject<T>(a);
               return bb; 
             }
             return default(T);
         }*/
    }
}
