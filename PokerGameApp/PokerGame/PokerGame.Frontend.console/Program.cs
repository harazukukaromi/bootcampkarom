using System;
using PokerGameApp;

namespace PokerGameApp.FrontendConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // === Inisialisasi backend ===
            IDeck deck = new Deck();
            deck.Initialize();
            deck.Shuffle(new Random());

            ICard dummyCard = new Card(Suit.Spades, Rank.Ace);
            IChip dummyChip = new Chip(ChipType.White);
            IPlayer dummyPlayer = new HumanPlayer("Initializer");
            ITable table = new Table(deck);

            PokerGame game = new PokerGame(table, dummyCard, dummyChip, deck, dummyPlayer);

            // === 1️⃣ Event untuk log (output ke layar) ===
            game.OnGameLog += message =>
            {
                Console.WriteLine(message);
            };

            // === 2️⃣ Event untuk input teks (nama, menu, dll.) ===
            game.OnRequestInput += prompt =>
            {
                Console.Write(prompt);
                return Console.ReadLine() ?? string.Empty;
            };

            // === 3️⃣ Event untuk input angka (jumlah bot, raise, dll.) ===
            game.OnRequestNumber += prompt =>
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine() ?? "";
                    if (int.TryParse(input, out int value))
                        return value;
                    Console.WriteLine("Input harus berupa angka!");
                }
            };

            // === 4️⃣ Event untuk aksi pemain (Check, Call, Fold, dll.) ===
            game.OnRequestDecision += player =>
            {
                Console.WriteLine($"{player.Name}, pilih aksi:");
                Console.WriteLine("[1] Check  [2] Call  [3] Raise  [4] All-In  [5] Fold");
                Console.Write("Pilih: ");
                string input = Console.ReadLine() ?? "";

                return input switch
                {
                    "1" => PlayerAction.Check,
                    "2" => PlayerAction.Call,
                    "3" => PlayerAction.Raise,
                    "4" => PlayerAction.AllIn,
                    "5" => PlayerAction.Fold,
                    _ => PlayerAction.Check
                };
            };

            // === 5️⃣ Event untuk jumlah raise (jika human memilih Raise) ===
            game.OnRequestRaiseAmount += (playerName, toCall, minRaise) =>
            {
                Console.WriteLine($"{playerName}, masukkan jumlah Raise (minimal {toCall + minRaise}): ");
                while (true)
                {
                    string input = Console.ReadLine() ?? "";
                    if (int.TryParse(input, out int raiseAmount))
                        return raiseAmount;
                    Console.WriteLine("Input tidak valid. Masukkan angka.");
                }
            };

            // === 6️⃣ Event status game (Fold, Raise, All-in, dll.) ===
            game.OnGameEvent += (evt, player) =>
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
                        Console.WriteLine($"[EVENT] {player?.Name} melakukan Fold.");
                        break;
                    case GameEventType.PlayerRaised:
                        Console.WriteLine($"[EVENT] {player?.Name} melakukan Raise.");
                        break;
                    case GameEventType.PlayerAllin:
                        Console.WriteLine($"[EVENT] {player?.Name} melakukan All-In!");
                        break;
                    case GameEventType.PlayerChecked:
                        Console.WriteLine($"[EVENT] {player?.Name} melakukan Check.");
                        break;
                    case GameEventType.PlayerCalled:
                        Console.WriteLine($"[EVENT] {player?.Name} melakukan Call.");
                        break;
                }
            };

            // === Jalankan game ===
            game.StartGame();
        }
    }
}