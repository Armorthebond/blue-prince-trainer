using Xunit;
using BluePrinceTrainer.Core;
using BluePrinceTrainer.Models;
using System.IO;

namespace BluePrinceTrainer.Tests;

public class TrainerServiceTests
{
    [Fact]
    public void LoadConfig_CreatesDefault_WhenFileMissing()
    {
        if (File.Exists("trainer_config.json"))
            File.Delete("trainer_config.json");

        var service = new TrainerService();
        var config = service.LoadConfig();

        Assert.NotNull(config);
        Assert.False(string.IsNullOrEmpty(config.GamePath));
        Assert.True(config.AutoSaveEnabled);
    }

    [Fact]
    public void SaveAndLoadConfig_Roundtrip()
    {
        var service = new TrainerService();
        var original = new TrainerConfig
        {
            GamePath = "/test/path",
            AutoSaveEnabled = false,
            UnlimitedResources = true,
            SpeedMultiplier = 3
        };

        service.SaveConfig(original);
        var loaded = service.LoadConfig();

        Assert.Equal(original.GamePath, loaded.GamePath);
        Assert.Equal(original.AutoSaveEnabled, loaded.AutoSaveEnabled);
        Assert.Equal(original.UnlimitedResources, loaded.UnlimitedResources);
        Assert.Equal(original.SpeedMultiplier, loaded.SpeedMultiplier);

        File.Delete("trainer_config.json");
    }

    [Fact]
    public void ApplyCheats_ReturnsFalse_WhenPathInvalid()
    {
        var service = new TrainerService();
        var config = new TrainerConfig
        {
            GamePath = @"Z:\nonexistent\path",
            UnlimitedResources = true
        };

        var result = service.ApplyCheats(config);
        Assert.False(result);
    }
}