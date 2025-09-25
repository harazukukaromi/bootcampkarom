/*
class Program
{
    static void Main()
    {
        // 🔹 Testing Enum Rank
        Console.WriteLine("=== Testing Enum Rank ===");
        Console.WriteLine($"Ace value: {(int)Rank.Ace} ({Rank.Ace})");
        foreach (Rank r in Enum.GetValues(typeof(Rank)))
        {
            Console.WriteLine($"{(int)r} -> {r}");
        }

        // 🔹 Testing Enum Suit
        Console.WriteLine("\n=== Testing Enum Suit ===");
        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            Console.WriteLine($"{(int)s} -> {s}");
        }

        // 🔹 Testing Enum ChipType
        Console.WriteLine("\n=== Testing Enum ChipType ===");
        foreach (ChipType c in Enum.GetValues(typeof(ChipType)))
        {
            Console.WriteLine($"{c} = {(int)c}");
        }

        // 🔹 Testing Player & Chips
        Console.WriteLine("\n=== Testing Player ===");
        IPlayer p1 = new HumanPlayer("Alice", 100);
        IPlayer p2 = new AIPlayer("BotX", 50);

        Console.WriteLine($"Player: {p1.Name}, Chips: {p1.Chips.Count}, Folded? {p1.IsFolded}");
        Console.WriteLine($"Player: {p2.Name}, Chips: {p2.Chips.Count}, Folded? {p2.IsFolded}");

        // 🔹 Testing Table & Deck
        Console.WriteLine("\n=== Testing Table & Deck ===");
        IDeck deck = new Deck();
        ITable table = new Table(deck);
        table.players.Add(p1);
        table.players.Add(p2);

        Console.WriteLine($"Total players di table: {table.players.Count}");
        Console.WriteLine($"Deck awal kosong? {deck.Cards.Count == 0}");
        Console.WriteLine($"Pot awal: {table.Pot.Count} chips");

         IPlayer richGuy = new HumanPlayer("RichGuy", 0); 
        for (int i = 0; i < 1000; i++)
        {
            richGuy.Chips.Add(new Chip(ChipType.Black));
        }

        Console.WriteLine($"Player: {richGuy.Name}");
        Console.WriteLine($"Total Chips: {richGuy.Chips.Count}");
        Console.WriteLine($"Tipe Chip Pertama: {richGuy.Chips[0].Type} = {(int)richGuy.Chips[0].Type}");
    }
}
class Program
{
    static void Main()
    {
        // bikin beberapa kartu manual
        var cards = new List<ICard>
        {
            new Card(Suit.Hearts, Rank.Ace),
            new Card(Suit.Hearts, Rank.Two),
            new Card(Suit.Hearts, Rank.Three),
            new Card(Suit.Hearts, Rank.Four),
            new Card(Suit.Hearts, Rank.Five),
            new Card(Suit.Clubs, Rank.Two),
            new Card(Suit.Diamonds, Rank.Three)
        };

        var game = new PokerGame(new Table(new Deck()));

        string bestHand = game.EvaluateBestHand(cards);

        Console.WriteLine("Best Hand: " + bestHand); 
        // Checking Output
    }
}
public class Program
//Testing Player
    {
        public static void Main()
        {
            var table = new Table(new Deck());
            var game = new PokerGame(table);

            var p1 = new HumanPlayer("Hikaromi", 1000);
            var p2 = new HumanPlayer("Kanafrost", 1000);
            var p3 = new HumanPlayer("Chun", 1000);
            var p4 = new HumanPlayer("Skelek", 1000);
            var p5 = new HumanPlayer("Patrick", 1000);

            game.AddPlayer(p1); // bisa
            game.AddPlayer(p1); // tidak bisa karena player sudah ada
            game.AddPlayer(new HumanPlayer("Hikaromi", 1000)); // tidak bisa karena nama player sudah ada di game
            game.AddPlayer(p2); // bisa
            game.AddPlayer(p3); // bisa
            game.AddPlayer(p4); // bisa
            game.AddPlayer(p5); // tidak bisa karena player sudah maksimal
 
            Console.WriteLine("\n--- Daftar pemain di meja ---");
            foreach (var player in game.GetPlayers())
            {
                Console.WriteLine(player.Name);
            }

            // test hapus player
            game.RemovePlayer(p2); // hapus Kanafrost
            game.RemovePlayer(p3); // hapus Chun
            game.RemovePlayer(p5); // gagal hapus karena tidak ada

            Console.WriteLine("\n Daftar pemain setelah penghapusan ");
            foreach (var player in game.GetPlayers())
            {
                Console.WriteLine(player.Name);
            }
        }
    }
*/