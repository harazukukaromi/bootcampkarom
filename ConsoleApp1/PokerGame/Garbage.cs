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

    // tambahan kelas untuk sementara
    private List<Chip> RemoveChipsFromPlayer(IPlayer player, int amount)
    {
        var removed = new List<Chip>();
        int need = amount;
        // try taking large chips first for efficiency
        var ordering = new[] { ChipType.Black, ChipType.Green, ChipType.Red, ChipType.White };
        foreach (var type in ordering)
        {
            while (need > 0 && player.Chips.Any(c => c.Type == type))
            {
                var chip = player.Chips.First(c => c.Type == type);
                removed.Add(chip);
                player.Chips.Remove(chip);
                need -= (int)chip.Type;
            }
        }

        // if player didn't have enough, they went all-in with removed chips (need may be >0)
        if (need > 0)
        {
            // that's fine - all-in. removed contains all chips the player had.
        }

        // after removing, normalize player's chips (if some conversions possible)
        NormalizeChips(player.Chips);

        return removed;
    }

    private void AddChipsListToPot(IEnumerable<Chip> chips)
    {
        if (chips == null) return;
        _table.Pot.AddRange(chips);
        NormalizeChips(_table.Pot); // keep pot normalized
    }

    private void AddChipsListToPlayer(IPlayer player, IEnumerable<Chip> chips)
    {
        if (chips == null) return;
        player.Chips.AddRange(chips);
        NormalizeChips(player.Chips);
    }

    private void NormalizeChips(List<Chip> chips)
    {
        if (chips == null) return;

        // White -> Red : 5 whites -> 1 red
        while (chips.Count(c => c.Type == ChipType.White) >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                var w = chips.First(c => c.Type == ChipType.White);
                chips.Remove(w);
            }
            chips.Add(new Chip(ChipType.Red));
        }

        // Red -> Green : 2 reds -> 1 green
        while (chips.Count(c => c.Type == ChipType.Red) >= 2)
        {
            for (int i = 0; i < 2; i++)
            {
                var r = chips.First(c => c.Type == ChipType.Red);
                chips.Remove(r);
            }
            chips.Add(new Chip(ChipType.Green));
        }

        // Green -> Black : 10 greens -> 1 black
        while (chips.Count(c => c.Type == ChipType.Green) >= 10)
        {
            for (int i = 0; i < 10; i++)
            {
                var g = chips.First(c => c.Type == ChipType.Green);
                chips.Remove(g);
            }
            chips.Add(new Chip(ChipType.Black));
        }
    }

    private int GetPotValue() => _table.Pot.Sum(c => (int)c.Type);

    private void SplitPotEvenlyAmong(List<IPlayer> winners)
    {
        if (winners == null || winners.Count == 0) return;
        // naive equal-split: convert pot to total value, divide by winners, then distribute as AddChipsToPlayer
        int total = GetPotValue();
        int per = total / winners.Count;
        _table.Pot.Clear();

        foreach (var w in winners)
        {
            AddChipsToPlayerByAmount(w, per);
            Console.WriteLine($"{w.Name} receives {per} from pot (split).");
        }
    }

    private void AddChipsToPlayerByAmount(IPlayer player, int amount)
    {
        int remaining = amount;
        var toAdd = new List<Chip>();
        while (remaining > 0)
        {
            if (remaining >= (int)ChipType.Black) { toAdd.Add(new Chip(ChipType.Black)); remaining -= (int)ChipType.Black; }
            else if (remaining >= (int)ChipType.Green) { toAdd.Add(new Chip(ChipType.Green)); remaining -= (int)ChipType.Green; }
            else if (remaining >= (int)ChipType.Red) { toAdd.Add(new Chip(ChipType.Red)); remaining -= (int)ChipType.Red; }
            else { toAdd.Add(new Chip(ChipType.White)); remaining -= (int)ChipType.White; }
        }
        player.Chips.AddRange(toAdd);
        NormalizeChips(player.Chips);
    }

    // utility: display table state
    public void ShowTableState()
    {
        Console.WriteLine("\n=== TABLE STATE ===");
        Console.WriteLine("Players:");
        foreach (var p in _players)
        {
            var chipGroups = p.Chips.GroupBy(c => c.Type).Select(g => $"{g.Key}x{g.Count()}");
            Console.WriteLine($"- {p.Name} | Chips: {p.Chips.Sum(c => (int)c.Type)} [{string.Join(", ", chipGroups)}] | Folded: {p.IsFolded}");
        }
        Console.WriteLine($"Pot value: {GetPotValue()} | Pot chips: {string.Join(", ", _table.Pot.Select(c => c.Type))}");
        ShowBoard();
        Console.WriteLine("===================\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Buat deck & table
        IDeck deck = new Deck();
        Table table = new Table(deck);

        Console.WriteLine("=== Texas Hold'em Poker ===");
        Console.Write("Masukkan jumlah player (1-4): ");
        int jumlahPlayer = int.Parse(Console.ReadLine() ?? "2");

        for (int i = 1; i <= jumlahPlayer; i++)
        {
            Console.WriteLine($"\nPlayer {i}:");

            string pilihan;
            while (true)
            {
                Console.Write("Pilih tipe (1 = Human, 2 = AI): ");
                pilihan = Console.ReadLine()?.Trim() ?? "";

                if (pilihan == "1" || pilihan == "2")
                    break;

                Console.WriteLine(" Input tidak valid! Harus 1 (Human) atau 2 (AI).");
            }

            Console.Write("Masukkan nama player: ");
            string nama = Console.ReadLine() ?? $"Player{i}";

            Console.Write("Masukkan jumlah chip awal (misal 1000): ");
            int initialChips = int.Parse(Console.ReadLine() ?? "1000");

            IPlayer player;

            if (pilihan == "1")
            {
                player = new HumanPlayer(nama, initialChips);
                Console.WriteLine($"{nama} (Human) ditambahkan ke meja dengan {initialChips} chips.");
            }
            else
            {
                player = new AIPlayer(nama, initialChips);
                Console.WriteLine($"{nama} (AI) ditambahkan ke meja dengan {initialChips} chips.");
            }

            table.players.Add(player);
        }

        // Mulai game
        PokerGame game = new PokerGame(table, null, null, deck, null);
        game.StartGame();
    }
}


public string EvaluateHand(List<ICard> handCards, List<ICard> communityCards)
    {
        var allCards = handCards.Concat(communityCards).ToList();
        return EvaluateBestHand(allCards);
    }


class Program
{
    static void Main(string[] args)
    {
        IDeck deck = new Deck();
        Table table = new Table(deck);
        PokerGame game = new PokerGame(table);

        Console.WriteLine("=== Texas Hold'em Poker ===");

        // Player 1 selalu Human
        game.AddPlayer("Hikaromi", false);

        // Player 2-4 otomatis Bot
        game.AddPlayer("Bot2", true);
        game.AddPlayer("Bot3", true);
        game.AddPlayer("Bot4", true);

        // 🔥 Atur manual balance biar simulasi special case
        var players = game.GetPlayers();
        players.First(p => p.Name == "Bot2").Balance = 1240; // normal SB
        players.First(p => p.Name == "Bot3").Balance = 10;   // special case BB
        players.First(p => p.Name == "Bot4").Balance = 1000; // normal

        // Mulai game
        game.StartGame();

        Console.WriteLine("\n=== Game Selesai ===");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDeck deck = new Deck();
        Table table = new Table(deck);
        PokerGame game = new PokerGame(table);

        Console.WriteLine("=== Texas Hold'em Poker ===");

        // Player 1 selalu Human
        game.AddPlayer("Hikaromi", false);

        // Player 2-4 otomatis Bot
        game.AddPlayer("Bot2", true);
        game.AddPlayer("Bot3", true);
        game.AddPlayer("Bot4", true);

        // 🔥 Atur kondisi khusus
        var players = game.GetPlayers();
        players.First(p => p.Name == "Hikaromi").Balance = 1000;
        players.First(p => p.Name == "Bot2").Balance = 1230; // normal SB
        players.First(p => p.Name == "Bot3").Balance = 10;   // special case BB (all-in)
        players.First(p => p.Name == "Bot4").Balance = 5;    // langsung dianggap bangkrut (< 10)

        // Mulai game
        game.StartGame();

        Console.WriteLine("\n=== Game Selesai ===");
    }
}
*/