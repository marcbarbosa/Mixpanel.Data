using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Mixpanel.Data.Extensions
{
    public static class CollectionExtension
    {
        public static string ToQueryString(this NameValueCollection nameValueCollection)
        {
            return nameValueCollection.AllKeys.ToDictionary(key => key, key => nameValueCollection[key]).ToQueryString();
        }

        public static string ToQueryString(this IEnumerable<KeyValuePair<string, string>> dictionary)
        {
            return string.Join("&", dictionary.ToList().Select(d => string.Format("{0}={1}", d.Key, d.Value)).ToList());
        }

        public static void AddIfNotIsNullOrWhiteSpace(this NameValueCollection nameValueCollection, string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(name)
             && !string.IsNullOrWhiteSpace(value))
            {
                nameValueCollection.Add(name, value);
            }
        }
    }
}
