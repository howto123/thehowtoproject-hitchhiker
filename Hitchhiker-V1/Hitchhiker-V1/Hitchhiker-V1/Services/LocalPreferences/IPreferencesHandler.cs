namespace Services.LocalPreferences
{
    /// <summary>
    /// This interface is responsible for locally storing data.
    /// </summary>
    internal interface IPreferencesHandler
    {
        string GetPreference(string key);
        void SetPreference(string key, string value);
    }
}