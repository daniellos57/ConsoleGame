using somewirdsht;
using System.Text.Json;

using System;
using System.IO;
using System.Text.Json;

public class HeroManager
{
    private const string FilePath = "heroData.json";

    // Zapisz dane bohatera do pliku JSON
    public static void SaveHero(Hero hero)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(hero, options);
        File.WriteAllText(FilePath, json);
    }

    // Wczytaj dane bohatera z pliku JSON i zwróć obiekt Hero
    public static Hero LoadHero()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("Plik z danymi nie istnieje, tworzony jest nowy bohater.");
            return new Hero();  // Tworzymy nowego bohatera, jeśli plik nie istnieje
        }

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<Hero>(json);  // Zwracamy odczytanego bohatera
    }
}
