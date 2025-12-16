using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IsVPNOn
{
    [Serializable]
    public class AppData
    {
        public string? whiteIP { get; set; }
        public string? serverIP { get; set; }

        public void SaveAppData()
        {
            string appDataPath = ConfigManager.AppDataPath;

            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                string directory = Path.GetDirectoryName(appDataPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(appDataPath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка сохранения настроек: {ex.Message}");
            }
        }
        public static AppData? LoadAppData()
        {
            string appDataPath = ConfigManager.AppDataPath;
            try
            {
                if (File.Exists(appDataPath))
                {
                    string json = File.ReadAllText(appDataPath);
                    AppData? appData = JsonSerializer.Deserialize<AppData>(json);
                    return appData;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки настроек: {ex.Message}");
            }
            return null;
        }
    }

}
