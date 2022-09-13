using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Hitchhiker_V1.Services
{
    internal class PreferencesHandler
    {
        // As this is a singleton, there is a public accessor (singleton is not thread safe, but that's ok here)
        public static PreferencesHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new PreferencesHandler();
            }
            return instance;
        }

        // public methods
        public void SetPreference(string key, string value)
        {
            Preferences.Set(key, value);
        }
        public string GetPreference(string key)
        {
            if (!Preferences.ContainsKey(key))
            {
                return null;
                //throw new Exception($"key '{key}' does not seem to be stored in the preferences");
            }
            return Preferences.Get(key, null);
        }

        // private attribute (the singleton instance)
        private static PreferencesHandler instance = null;

        // private constructor
        private PreferencesHandler()
        {
            //constructor does nothing
            Console.WriteLine("PreferenceHandler constuctor called");
        }
    }
}
