using System;
using BluePrinceTrainer.Core;
using BluePrinceTrainer.Models;

namespace BluePrinceTrainer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Blue Prince Trainer v1.0");
        Console.WriteLine("-----------------------");

        var trainer = new TrainerService();
        var config = trainer.LoadConfig();

        Console.WriteLine($"Game Path: {config.GamePath}");
        Console.WriteLine($"Auto Save: {config.AutoSaveEnabled}");
        Console.WriteLine($"Unlimited Resources: {config.UnlimitedResources}");

        if (args.Length > 0 && args[0] == "--apply")
        {
            var result = trainer.ApplyCheats(config);
            Console.WriteLine(result ? "Cheats applied successfully." : "Failed to apply cheats.");
        }
        else
        {
            Console.WriteLine("Run with --apply to activate cheats.");
        }
    }
}