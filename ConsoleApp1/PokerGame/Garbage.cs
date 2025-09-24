/*
        Console.WriteLine("\nSemua rank kartu:");
        for (int r = 2; r <= 14; r++)
        {
            Rank rank = (Rank)r;
            Console.WriteLine($"{r} -> {rank}");
        }

//Checking for EnumRank
public class Program
{
    static void Main()
    {
        // Mengambil rank Ace
        Rank myCardRank = Rank.King;

        // Menampilkan nilai numerik
        Console.WriteLine("Nilai numerik kartu: " + (int)myCardRank); // Output: 14

        // Menampilkan nama rank
        Console.WriteLine("Nama rank kartu: " + myCardRank); // Output: "Ace"
    }
}
//checking for EnumSuit
class Program
{
    static void Main()
    {
        // Ambil salah satu suit
        Suit mySuit = Suit.Clubs;

        // Menampilkan nilai enum (nama suit)
        Console.WriteLine("Nama suit: " + mySuit); // Output: Spades

        // Menampilkan nilai numerik enum
        Console.WriteLine("Nilai numerik suit: " + (int)mySuit); // Output: 3 (karena mulai dari 0)

        // Loop semua suit
        Console.WriteLine("\nSemua suit:");
        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            Console.WriteLine($"{(int)s} -> {s}");
        }
    }
}
*/