namespace BluePrinceTrainer.Models;

public class TrainerConfig
{
    public string GamePath { get; set; } = string.Empty;
    public bool AutoSaveEnabled { get; set; } = false;
    public bool UnlimitedResources { get; set; } = false;
    public int SpeedMultiplier { get; set; } = 1;
}