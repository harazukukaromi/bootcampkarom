/*using System;

class Enum
{
    // Enum didefinisikan di dalam class
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public Season CurrentSeason { get; set; }

    public Enum(Season season)
    {
        CurrentSeason = season;
    }

    public void DescribeSeason()
    {
        Console.WriteLine($"Current season: {CurrentSeason}");

        switch (CurrentSeason)
        {
            case Season.Spring:
                Console.WriteLine("Musim Semi Mari Bercocok tanam");
                break;
            case Season.Summer:
                Console.WriteLine("Musim Panas Mari Merayakan Kembang api");
                break;
            case Season.Autumn:
                Console.WriteLine("Musim gugur Waktunya Berpanen");
                break;
            case Season.Winter:
                Console.WriteLine("Musim Dingin Mari menghangatkan Tubuh");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        Enum myClass = new Enum(Enum.Season.Summer); //Spring, Summer, Autumn, Winter
        myClass.DescribeSeason();
    }
}*/