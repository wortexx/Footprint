using System.IO.IsolatedStorage;

namespace Mobile.Common.Infrastructure
{
    public static class IsolatedStorageHelper
    {
        public const string IsTrackingRunningKey = "IsTrackingRunning";
        public const string PositionPointListKey = "PositionPointList";
        public const string AuthenticationTokenKey = "AuthenticationToken";

        public static T GetValue<T>(string key)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                IsolatedStorageSettings.ApplicationSettings.Add(key, XmlHelper.Serialize(default(T)));
            }

            var result = IsolatedStorageSettings.ApplicationSettings[key];
            return XmlHelper.DeSerialize<T>(result.ToString());
        }

        public static void SetValue<T>(string key, T value)
        {
            string xml = XmlHelper.Serialize(value);
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                IsolatedStorageSettings.ApplicationSettings.Add(key, xml);
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings[key] = xml;
            }
        }

        public static void RemoveValue(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove(key);
            }
        }
    }
}