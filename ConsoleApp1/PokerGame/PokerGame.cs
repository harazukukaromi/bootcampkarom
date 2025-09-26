
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
//enum
public enum Rank
{
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
    Ace = 14
}

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}
public enum PlayerAction
{
    Fold,
    Call,
    Raise,
    AllIn
}
public enum GameEventType
{
    GameStarted,
    RoundEnded,
    PlayerFolded,
    PlayerRaised,
}
public enum ChipType
{
    White = 10,
    Red = 50,
    Green = 100,
    Black = 1000
}
//Interface
public interface ICard
{
    Suit Suit { get; }
    Rank Rank { get; }
}
public interface IChip
{
    ChipType Type { get; }
}

public interface IDeck
{
    List<ICard> Cards { get; }
    int CardsRemaining { get; }
}
public interface IHand
{
    List<ICard> Cards { get; }
}
public interface IPlayer
{
    string Name { get; }
    IHand Hand { get; }
    List<Chip> Chips { get; }
    bool IsFolded { get; set; }
    int CurrentBet { get; set; }
}

public interface ITable
{
    List<IPlayer> players { get; }
    IDeck Deck { get; }
    List<Chip> Pot { get; }
}

public class Card : ICard
{
    public Suit Suit { get; }
    public Rank Rank { get; }
    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }
}
public class Deck : IDeck
{
    private List<ICard> _cards = new();
    public List<ICard> Cards => _cards;
    public int CardsRemaining => _cards.Count;
}
public class Hand : IHand
{
    private List<ICard> _cards = new();
    public List<ICard> Cards => _cards;

    public void AddCard(ICard card) => _cards.Add(card);
}

public class Chip : IChip
{
    public ChipType Type { get; }
    public Chip(ChipType type) => Type = type;
}

public class HumanPlayer : IPlayer
{
    public string Name { get; }
    public IHand Hand { get; } = new Hand();
    public List<Chip> Chips { get; } = new();
    public bool IsFolded { get; set; }
    public int CurrentBet { get; set; }

    public HumanPlayer(string name, int initialChips)
    {
        Name = name;
        for (int i = 0; i < initialChips / 10; i++)
            Chips.Add(new Chip(ChipType.White));
    }
}
public class AIPlayer : IPlayer
{
    public string Name { get; }
    public IHand Hand { get; } = new Hand();
    public List<Chip> Chips { get; } = new();
    public bool IsFolded { get; set; }
    public int CurrentBet { get; set; }

    public AIPlayer(string name, int initialChips)
    {
        Name = name;
        for (int i = 0; i < initialChips / 10; i++)
            Chips.Add(new Chip(ChipType.White));
    }
}

public class Table : ITable
{
    public List<IPlayer> players { get; } = new();
    public IDeck Deck { get; }
    public List<Chip> Pot { get; } = new();

    public Table(IDeck deck)
    {
        Deck = deck;
    }
}
public class PokerGame
{
    private readonly ITable _table;
    private readonly Random _random;
    private readonly List<ICard> _communityCards;
    private int _currentBet;
    private int _minRaise;
    private int _bigBlind;
    private int _smallBlindIndex;
    private int _bigBlindIndex;

    // helper collections
    private readonly List<IPlayer> _players = new();

    public Action<GameEventType>? OnGameEvent;
    public Action<IPlayer, string, int>? OnGameEnded;
    public Func<IPlayer, int, int, PlayerAction>? OnPlayerDecision;

    public PokerGame(ITable table, ICard card = null, IChip chip = null, IDeck deck = null, IPlayer player = null)//ICard card, IChip chip, IDeck deck, IPlayer player)
    {
        _table = table ?? throw new ArgumentNullException(nameof(table));
        _random = new Random();
        _communityCards = new List<ICard>();

        // if external deck provided, prefer table's deck; ensure deck is initialized elsewhere
        if (_table.Deck == null && deck != null)
        {
            // nothing to do here unless you change Table implementation; assume table.Deck set
        }

        // optional initial player
        if (player != null)
            AddPlayer(player);

        // optional initial community card
        if (card != null)
            _communityCards.Add(card);

        // optional initial chip into pot
        if (chip != null)
            _table.Pot.Add(new Chip(chip.Type));

        // defaults
        _minRaise = 5;
        _bigBlind = 10;
        _smallBlindIndex = 0;
        _bigBlindIndex = 1;
    }
    public void StartGame()
    {
        Console.WriteLine("Game Start!");
        ResetDeck();         // refill deck
        ShuffleDeck();
        _communityCards.Clear();
        _players.Clear();
        _players.AddRange(_table.players); // sync players list

        if (_players.Count < 2)
        {
            Console.WriteLine("Tidak cukup pemain untuk memulai (minimal 2).");
            return;
        }

        ResetRound();
        PostBlinds();
        DealCards();
        BettingRounds(); // pre-flop

        // Flop
        DealCommunityCards(3);
        BettingRounds();

        // Turn
        DealCommunityCards(1);
        BettingRounds();

        // River
        DealCommunityCards(1);
        BettingRounds();

        Showdown();
        DistributePot();
    }
    private void PlayRound()
    {
        Console.WriteLine("Game Dimulai"); //game mulai for start every round   
    }
    
    private void ResetRound()
    {
        _communityCards.Clear();
        _currentBet = 0;
        // reset player state
        foreach (var p in _players)
        {
            p.IsFolded = false;
            p.CurrentBet = 0;
            p.Hand.Cards.Clear();
        }
        Console.WriteLine("Round baru dimulai.");
    }
    private void DealCards()
    {
        Console.WriteLine("\n-- Dealing 2 hole cards to each player --");
        foreach (var p in _players)
        {
            // draw 2 cards
            var c1 = DealCardDeck();
            var c2 = DealCardDeck();
            ((Hand)p.Hand).AddCard(c1);
            ((Hand)p.Hand).AddCard(c2);
            Console.WriteLine($"{p.Name} gets: {c1.Rank} of {c1.Suit}, {c2.Rank} of {c2.Suit}");
        }
    }
    private void DealCommunityCards(int count)
    {
        Console.WriteLine($"\n-- Dealing {count} community card(s) --");
        for (int i = 0; i < count; i++)
        {
            var c = DealCardDeck();
            _communityCards.Add(c);
        }
        ShowBoard();
    }
    private void ShowBoard()//tambahan kelas untuk menampilkan class untuk show card
    {
        Console.WriteLine("Board:");
        if (_communityCards.Count == 0) Console.WriteLine("  (empty)");
        else
        {
            foreach (var c in _communityCards)
                Console.WriteLine($"  {c.Rank} of {c.Suit}");
        }
    }
    private void PostBlinds()
    {
        Console.WriteLine("Board:");
        if (_communityCards.Count == 0) Console.WriteLine("  (empty)");
        else
        {
            foreach (var c in _communityCards)
                Console.WriteLine($"  {c.Rank} of {c.Suit}");
        }
    }
    private void BettingRounds()
    {
        Console.WriteLine("\n-- Betting Round --");
        // very simplified: each active player will 'call' current bet if possible,
        // or go all-in with whatever they have
        foreach (var p in _players)
        {
            if (p.IsFolded) continue;

            // compute how much player needs to call
            int needToCall = _currentBet - p.CurrentBet;
            if (needToCall <= 0)
            {
                Console.WriteLine($"{p.Name} checks.");
                continue;
            }

            // decide action via callback if provided
            PlayerAction action = PlayerAction.Call;
            if (OnPlayerDecision != null)
            {
                try { action = OnPlayerDecision(p, _currentBet, _minRaise); }
                catch { action = PlayerAction.Call; }
            }

            if (action == PlayerAction.Fold)
            {
                p.IsFolded = true;
                Console.WriteLine($"{p.Name} folds.");
                continue;
            }

            if (action == PlayerAction.AllIn)
            {
                int have = p.Chips.Sum(c => (int)c.Type);
                var chipsAllIn = RemoveChipsFromPlayer(p, have);
                AddChipsListToPot(chipsAllIn);
                p.CurrentBet += have;
                Console.WriteLine($"{p.Name} goes ALL IN with {have}.");
                if (have > _currentBet) _currentBet = have;
                continue;
            }

            if (action == PlayerAction.Raise)
            {
                int raiseAmount = _minRaise; // default raise
                var raiseChips = RemoveChipsFromPlayer(p, needToCall + raiseAmount);
                AddChipsListToPot(raiseChips);
                p.CurrentBet += needToCall + raiseAmount;
                _currentBet = p.CurrentBet;
                Console.WriteLine($"{p.Name} raises to {_currentBet}.");
                continue;
            }

            // default Call
            var callChips = RemoveChipsFromPlayer(p, needToCall);
            AddChipsListToPot(callChips);
            p.CurrentBet += needToCall;
            Console.WriteLine($"{p.Name} calls {needToCall}.");
        }
    }
    private void ProcessPlayerTurn(IPlayer player, PlayerAction action)
    {

    }
    private void Showdown()
    {
        Console.WriteLine("\n-- Showdown --");
        // Evaluate best hand for each non-folded player
        // ganti definisi results
        List<(IPlayer player, HandResult result)> results = new();


        foreach (var p in _players)
        {
            if (p.IsFolded) continue;

            var playerCards = p.Hand.Cards.ToList();
            HandResult result = EvaluateHand(playerCards, _communityCards);

            results.Add((p, result));
            Console.WriteLine($"{p.Name}: {result.Name} (Strength: {result.Strength}) " +
                            $"Kickers: {string.Join(", ", result.Kickers)}");
        }


        if (results.Count == 0)
        {
            Console.WriteLine("No players in showdown.");
            return;
        }

        // find winner(s)
        int best = results.Max(r => r.result.Strength);

    var winners = results
        .Where(r => r.result.Strength == best)
        .Select(r => r.player)
        .ToList();

        if (winners.Count == 1)
        {
            Console.WriteLine($"Winner: {winners[0].Name}");
            // transfer pot chips to winner
            var potChips = _table.Pot.ToList();
            _table.Pot.Clear();
            AddChipsListToPlayer(winners[0], potChips);
        }
        else
        {
            Console.WriteLine("Tie between: " + string.Join(", ", winners.Select(w => w.Name)));
            // split pot evenly by value - simple approach: distribute chips equally as lists (not perfect)
            SplitPotEvenlyAmong(winners);
        }
    }
    private void DistributePot()
    {
        //untuk dealer kedepannya
    }

    public class HandResult
    {
        public string Name { get; set; } = "High Card";
        public int Strength { get; set; } = 1;
        public List<int> Kickers { get; set; } = new(); // untuk pembanding tambahan
    }


    private HandResult EvaluateBestHand(List<ICard> cards)
     {
        var allCombos = GetCombinations(cards, 5);

        HandResult best = new HandResult { Name = "High Card", Strength = 1, Kickers = new List<int>() };

        foreach (var combo in allCombos)
        {
            var result = EvaluateFiveCardHand(combo);

            if (result.Strength > best.Strength ||
                (result.Strength == best.Strength && CompareKickers(result.Kickers, best.Kickers) > 0))
            {
                best = result;
            }
        }

        return best;
    }
    private HandResult EvaluateFiveCardHand(List<ICard> cards)
    {
        string hand;
        if (IsRoyalFlush(cards)) hand = "Royal Flush";
        else if (IsStraightFlush(cards)) hand = "Straight Flush";
        else if (IsFourOfAKind(cards)) hand = "Four of a Kind";
        else if (IsFullHouse(cards)) hand = "Full House";
        else if (IsFlush(cards)) hand = "Flush";
        else if (IsStraight(cards)) hand = "Straight";
        else if (IsThreeOfAKind(cards)) hand = "Three of a Kind";
        else if (IsTwoPair(cards)) hand = "Two Pair";
        else if (IsOnePair(cards)) hand = "One Pair";
        else hand = "High Card";

        // Urutkan kartu dari yang paling tinggi → untuk kickers
        var sortedRanks = cards
            .Select(c => (int)c.Rank)
            .OrderByDescending(v => v)
            .ToList();

        var result = new HandResult
        {
            Name = hand,
            Strength = GetHandStrength(hand),
            Kickers = sortedRanks
        };

        // Tambahkan informasi kicker khusus High Card
        if (hand == "High Card")
            {
                var rankNames = cards
                    .OrderByDescending(c => c.Rank)
                    .Select(c => c.Rank.ToString())
                    .ToList();

                string mainHigh = rankNames.First();
                string kickerInfo = string.Join(", ", rankNames.Skip(1));

                result.Name = $"High Card {mainHigh} (Kickers: {kickerInfo})";
            }


        return result;
    }


    public IEnumerable<List<ICard>> GetCombinations(List<ICard> cards, int k)
    {
        int n = cards.Count;
        int[] indices = new int[k];
        for (int i = 0; i < k; i++) indices[i] = i;

        while (true)
        {
            yield return indices.Select(i => cards[i]).ToList();

            int t = k - 1;
            while (t >= 0 && indices[t] == n - k + t) t--;
            if (t < 0) yield break;

            indices[t]++;
            for (int i = t + 1; i < k; i++)
                indices[i] = indices[i - 1] + 1;
        }
    }
    public HandResult EvaluateHand(List<ICard> handCards, List<ICard> communityCards)
    {
        var allCards = handCards.Concat(communityCards).ToList();
        return EvaluateBestHand(allCards);
    }
    public int GetHandStrength(string hand) => hand switch
    {
        "Royal Flush" => 10,
        "Straight Flush" => 9,
        "Four of a Kind" => 8,
        "Full House" => 7,
        "Flush" => 6,
        "Straight" => 5,
        "Three of a Kind" => 4,
        "Two Pair" => 3,
        "One Pair" => 2,
        "High Card" => 1
    };
    private int CompareKickers(List<int> k1, List<int> k2)
    {
        int count = Math.Min(k1.Count, k2.Count);
        for (int i = 0; i < count; i++)
        {
            if (k1[i] > k2[i]) return 1;
            if (k1[i] < k2[i]) return -1;
        }
        return 0;
    }


    private bool IsRoyalFlush(List<ICard> cards) =>
        IsStraightFlush(cards) && cards.Any(c => c.Rank == Rank.Ace) && cards.Any(c => c.Rank == Rank.King);
    private bool IsStraightFlush(List<ICard> cards) =>
        IsFlush(cards) && IsStraight(cards);
    private bool IsFourOfAKind(List<ICard> cards) =>
        cards.GroupBy(c => c.Rank).Any(g => g.Count() == 4);
    private bool IsFullHouse(List<ICard> cards)
    {
        var groups = cards.GroupBy(c => c.Rank).ToList();
        return groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
    }
    private bool IsFlush(List<ICard> cards) =>
        cards.GroupBy(c => c.Suit).Any(g => g.Count() == 5);

    private bool IsStraight(List<ICard> cards)
    {
        var ranks = cards.Select(c => (int)c.Rank).Distinct().OrderBy(r => r).ToList();

        // Ace sebagai 1 (low straight A-2-3-4-5)
        if (ranks.Contains((int)Rank.Ace))
            ranks.Insert(0, 1);

        int consecutive = 1;
        for (int i = 1; i < ranks.Count; i++)
        {
            if (ranks[i] == ranks[i - 1] + 1)
            {
                consecutive++;
                if (consecutive >= 5) return true;
            }
            else
            {
                consecutive = 1;
            }
        }
        return false;
    }

    private bool IsThreeOfAKind(List<ICard> cards) =>
        cards.GroupBy(c => c.Rank).Any(g => g.Count() == 3);
    private bool IsTwoPair(List<ICard> cards) =>
        cards.GroupBy(c => c.Rank).Count(g => g.Count() == 2) >= 2;
    private bool IsOnePair(List<ICard> cards) =>
        cards.GroupBy(c => c.Rank).Any(g => g.Count() == 2);
    private bool IsHighCard(List<ICard> cards)
    {
        return !IsOnePair(cards) &&
           !IsTwoPair(cards) &&
           !IsThreeOfAKind(cards) &&
           !IsStraight(cards) &&
           !IsFlush(cards) &&
           !IsFullHouse(cards) &&
           !IsFourOfAKind(cards) &&
           !IsStraightFlush(cards) &&
           !IsRoyalFlush(cards);
    }
    public void AddPlayer(IPlayer player)
    {
        if (_table.players.Count >= 4)
        {
            Console.WriteLine("Maksimal 4 pemain diperbolehkan di meja.");
            return;
        }

        // cek apakah player sudah ada (berdasarkan referensi atau nama)
        if (_table.players.Any(p => p == player || p.Name == player.Name))
        {
            Console.WriteLine($"Player {player.Name} sudah ada di meja.");
            return;
        }
        _table.players.Add(player);
        Console.WriteLine($"{player.Name} bergabung ke meja. Total players: {_table.players.Count}/4");
    }
    public void RemovePlayer(IPlayer player)
    {
        if (_table.players.Remove(player))
        {
            Console.WriteLine($"{player.Name} keluar dari meja. Total players: {_table.players.Count}/4");
        }
        else
        {
            Console.WriteLine($"Player {player.Name} tidak ditemukan di meja.");
        }
    }
    public List<IPlayer> GetPlayers() => _table.players;
    public void AddCard(ICard card) => _communityCards.Add(card);
    public void ClearCard() => _communityCards.Clear();
    public void ResetForNewRound() => ResetRound();
    public bool PlaceBet(int amount)
    {
        if (amount < _currentBet) return false;
        _currentBet = amount;
        return true;
    }

    public ICard DealCardDeck()
    {
        var deck = _table.Deck.Cards;
        if (deck.Count == 0) throw new InvalidOperationException("Deck kosong!");
        var card = deck[0];
        deck.RemoveAt(0);
        return card;
    }
    public void ResetDeck()
    {
        {
            _table.Deck.Cards.Clear();
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                    _table.Deck.Cards.Add(new Card(s, r));
        }
    }
    private void ShuffleDeck()// class tambahan sementar untuk mengocok deck
    {
        var deck = _table.Deck.Cards;
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            (deck[k], deck[n]) = (deck[n], deck[k]);
        }
    }
    public IDeck GotDeck() => _table.Deck;
    public int GetPot() => 1000;
    public void AddToPot(int amount)
    {
        // convert amount to chips greedy and add
        while (amount >= (int)ChipType.Black)
        {
            _table.Pot.Add(new Chip(ChipType.Black));
            amount -= (int)ChipType.Black;
        }
        while (amount >= (int)ChipType.Green)
        {
            _table.Pot.Add(new Chip(ChipType.Green));
            amount -= (int)ChipType.Green;
        }
        while (amount >= (int)ChipType.Red)
        {
            _table.Pot.Add(new Chip(ChipType.Red));
            amount -= (int)ChipType.Red;
        }
        while (amount >= (int)ChipType.White)
        {
            _table.Pot.Add(new Chip(ChipType.White));
            amount -= (int)ChipType.White;
        }
    }
    public void RecieveCard(ICard card) => _communityCards.Add(card);
    public void Fold()
    {

    }
    public PlayerAction MakeDecision(int currentBet, int minRaise) => PlayerAction.Call;
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

        // Tambahkan beberapa player (misal 2 human + 1 AI)
        IPlayer p1 = new HumanPlayer("Alice", 1000);
        IPlayer p2 = new HumanPlayer("Bob", 1000);
        IPlayer p3 = new AIPlayer("CharlieBot", 1000);

        table.players.Add(p1);
        table.players.Add(p2);
        table.players.Add(p3);

        // Buat game
        PokerGame game = new PokerGame(table);

        // Mulai permainan
        game.StartGame();

        Console.WriteLine("\n=== Game Selesai ===");
        game.ShowTableState();

        Console.WriteLine("Tekan ENTER untuk keluar...");
        Console.ReadLine();
    }
}

    

