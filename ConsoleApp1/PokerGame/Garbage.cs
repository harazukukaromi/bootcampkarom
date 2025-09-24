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
}*/