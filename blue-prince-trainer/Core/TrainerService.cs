using System;
using System.IO;
using Newtonsoft.Json;
using BluePrinceTrainer.Models;

namespace BluePrinceTrainer.Core;

public class TrainerService
{
    private const string ConfigFileName = "trainer_config.json";

    public TrainerConfig LoadConfig()
    {
        if (!File.Exists(ConfigFileName))
        {
            var defaultConfig = new TrainerConfig
            {
                GamePath = @"C:\Games\BluePrince",
                AutoSaveEnabled = true,
                UnlimitedResources = false,
                SpeedMultiplier = 1
            };
            SaveConfig(defaultConfig);
            return defaultConfig;
        }

        var json = File.ReadAllText(ConfigFileName);
        return JsonConvert.DeserializeObject<TrainerConfig>(json) ?? new TrainerConfig();
    }

    public void SaveConfig(TrainerConfig config)
    {
        var json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(ConfigFileName, json);
    }

    public bool ApplyCheats(TrainerConfig config)
    {
        try
        {
            if (!Directory.Exists(config.GamePath))
            {
                Console.WriteLine($"Error: Game path '{config.GamePath}' not found.");
                return false;
            }

            var saveFile = Path.Combine(config.GamePath, "save.dat");
            if (config.UnlimitedResources && File.Exists(saveFile))
            {
                File.WriteAllText(saveFile, "resources:999999\n");
                Console.WriteLine("Unlimited resources applied.");
            }

            if (config.AutoSaveEnabled)
            {
                Console.WriteLine("Auto-save enabled.");
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error applying cheats: {ex.Message}");
            return false;
        }
    }
}