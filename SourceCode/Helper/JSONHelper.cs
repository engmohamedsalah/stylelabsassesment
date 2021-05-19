using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Helper
{
    public static class JSONHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">data bytes that contains the json data</param>
        /// <returns>Object class with Type T</returns>
        /// <typeparam name="T"></typeparam>
        /// <remarks></remarks>
        public static T ConvertJsonByteArrayToObject<T>(this byte[] bytes)
        {
            var bytesAsString = Encoding.UTF8.GetString(bytes);
            var obj = JsonConvert.DeserializeObject<T>(bytesAsString);
            return obj;

        }
    }
}
