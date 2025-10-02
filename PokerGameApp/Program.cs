namespace PokerGameApp;
using PokerGameApp;

class Program
{
    static void Main(string[] args)
    {
        // buat semua dependency
        IDeck deck = new Deck();
        deck.Initialize();
        deck.Shuffle(new Random());

        ICard dummyCard = new Card(Suit.Spades, Rank.Ace); // contoh kartu awal
        IChip dummyChip = new Chip(ChipType.White);        // contoh chip awal
        IPlayer dummyPlayer = new HumanPlayer("Initializer"); // contoh player awal

        ITable table = new Table(deck);

        // masukkan dependency ke constructor
        PokerGame game = new PokerGame(table, dummyCard, dummyChip, deck, dummyPlayer);

        // event handler seperti biasa
        game.OnGameEvent += (evt, p) =>
        {
            switch (evt)
            {
                case GameEventType.GameStarted:
                    Console.WriteLine("[EVENT] Game dimulai!");
                    break;
                case GameEventType.RoundStart:
                    Console.WriteLine("[EVENT] Round baru dimulai.");
                    break;
                case GameEventType.RoundEnded:
                    Console.WriteLine("[EVENT] Round berakhir.");
                    break;
                case GameEventType.PlayerFolded:
                    Console.WriteLine($"[EVENT] {p?.Name} melakukan Fold.");
                    break;
                case GameEventType.PlayerRaised:
                    Console.WriteLine($"[EVENT] {p?.Name} melakukan Raise.");
                    break;
                case GameEventType.PlayerAllin:
                    Console.WriteLine($"[EVENT] {p?.Name} melakukan All-In!");
                    break;
                case GameEventType.PlayerChecked:
                    Console.WriteLine($"[EVENT] {p?.Name} melakukan Check.");
                    break;
                case GameEventType.PlayerCalled:
                    Console.WriteLine($"[EVENT] {p?.Name} melakukan Call.");
                    break;
            }
        };

        Console.WriteLine("=== Texas Hold'em Poker ===");

        // Human player
        Console.Write("Masukkan nickname untuk Player 1 (Human): ");
        string humanName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(humanName))
            humanName = "Player1";
        game.AddPlayer(humanName, false);

        // Tambahkan 3 bot
        for (int i = 2; i <= 4; i++)
        {
            string botName = $"Bot{i}";
            game.AddPlayer(botName, true);
        }

        // Mulai game
        game.StartGame();
    }

}
