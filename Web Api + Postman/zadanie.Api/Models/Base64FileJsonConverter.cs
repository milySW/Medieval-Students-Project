using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class converting Base64 string to Json.
    /// </summary>
    public class Base64FileJsonConverter : JsonConverter
    {
        /// <summary>
        /// Check if converting possible.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        /// <summary>
        /// Read Json file.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(!reader.Value.ToString().Contains("data:image/png;base64,"))
            {
                return Convert.FromBase64String(reader.Value as string);
            }
            return false;
        }

        /// <summary>
        /// Write Json file.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
