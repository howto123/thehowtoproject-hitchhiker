using Xamarin.Essentials;

namespace Services.LocalPreferences
{
    public class PreferencesHandler : IPreferencesHandler
    {
        public void SetPreference(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public string GetPreference(string key)
        {
            if (!Preferences.ContainsKey(key))
            {
                return null;
            }
            return Preferences.Get(key, null);
        }

        public void ClearAll()
        {
            Preferences.Clear();
        }
    }
}
