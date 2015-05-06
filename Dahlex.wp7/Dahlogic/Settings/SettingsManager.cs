using System;
using System.Runtime.Serialization;
using System.IO;
using System.IO.IsolatedStorage;
using Dahlex.Logic.Logger;

namespace Dahlex.Logic.Settings
{
    public class SettingsManager
    {
        public GameSettings LoadLocalSettings()
        {
            var settings = new GameSettings();
            using (IsolatedStorageFile root = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = new IsolatedStorageFileStream("dahlexsettings.xml", FileMode.OpenOrCreate, root))
                {
                    if (stream.Length > 0)
                    {
                        var serializer = new DataContractSerializer(typeof (GameSettings));
                        try
                        {
                            settings = (GameSettings) serializer.ReadObject(stream);
                        }
                        catch (Exception ex)
                        {
                            GameLogger.AddLineToLog(string.Format("Settings failed to load: {0}", ex.Message));
                        }
                    }
                    else
                    {
                        GameLogger.AddLineToLog(string.Format("No settings found"));                        
                    }
                }
            }

            return settings;
        }

        public void SaveLocalSettings(GameSettings settings)
        {
            using (IsolatedStorageFile root = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = new IsolatedStorageFileStream("dahlexsettings.xml", FileMode.Create, root))
                {
                    var serializer = new DataContractSerializer(typeof(GameSettings));
                    serializer.WriteObject(stream, settings);

                    GameLogger.AddLineToLog(string.Format("Settings saved"));
                }
            }
        }
    }
}