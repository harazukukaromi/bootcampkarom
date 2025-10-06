/*using System;
public enum Musim
{
    enum using codebyte
    None = 0,       //0000
    Spring = 1 << 0,  //0001
    Summer = 1 << 1,  //0010
    Autumn = 1 << 2,  //0100
    Winter = 1 << 3   //1000
}

class SeasonManager
{
    public Musim CurrentSeasons { get; set; }

    public SeasonManager(Musim seasons)
    {
        CurrentSeasons = seasons;
    }

    public void DescribeSeasons()
    {
        Console.WriteLine($"Current seasons: {CurrentSeasons}");

        if (CurrentSeasons.HasFlag(Musim.Spring))
            Console.WriteLine("Musim Semi: Mari bercocok tanam.");

        if (CurrentSeasons.HasFlag(Musim.Summer))
            Console.WriteLine("Musim Panas: Mari merayakan kembang api.");

        if (CurrentSeasons.HasFlag(Musim.Autumn))
            Console.WriteLine("Musim Gugur: Waktunya berpanen.");

        if (CurrentSeasons.HasFlag(Musim.Winter))
            Console.WriteLine("Musim Dingin: Mari menghangatkan tubuh.");
    }
}

class Program
{
    static void Main()
    {
        // Contoh kombinasi musim Spring dan Summer
        SeasonManager mySeasons = new SeasonManager(Musim.Spring | Musim.Summer);
        mySeasons.DescribeSeasons();

        Console.WriteLine();

        // Contoh musim Winter saja
        SeasonManager winterSeason = new SeasonManager(Musim.Winter);
        winterSeason.DescribeSeasons();
    }
}*/
