
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
    void Initialize();
    void Shuffle(Random rng);
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

     public void Initialize()
    {
        _cards.Clear();
        foreach (Suit s in Enum.GetValues(typeof(Suit)))
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
                _cards.Add(new Card(s, r));
    }

    public void Shuffle(Random rng)
    {
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (_cards[k], _cards[n]) = (_cards[n], _cards[k]);
        }
    }
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
        NormalizeChips(Chips);
    }
    private void NormalizeChips(List<Chip> chips)
    {
        if (chips == null) return;
        while (chips.Count(c => c.Type == ChipType.White) >= 5)
        {
            for (int i = 0; i < 5; i++) chips.Remove(chips.First(c => c.Type == ChipType.White));
            chips.Add(new Chip(ChipType.Red));
        }
        while (chips.Count(c => c.Type == ChipType.Red) >= 2)
        {
            for (int i = 0; i < 2; i++) chips.Remove(chips.First(c => c.Type == ChipType.Red));
            chips.Add(new Chip(ChipType.Green));
        }
        while (chips.Count(c => c.Type == ChipType.Green) >= 10)
        {
            for (int i = 0; i < 10; i++) chips.Remove(chips.First(c => c.Type == ChipType.Green));
            chips.Add(new Chip(ChipType.Black));
        }
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
        NormalizeChips(Chips);
    }
    private void NormalizeChips(List<Chip> chips)
    {
        if (chips == null) return;
        while (chips.Count(c => c.Type == ChipType.White) >= 5)
        {
            for (int i = 0; i < 5; i++) chips.Remove(chips.First(c => c.Type == ChipType.White));
            chips.Add(new Chip(ChipType.Red));
        }
        while (chips.Count(c => c.Type == ChipType.Red) >= 2)
        {
            for (int i = 0; i < 2; i++) chips.Remove(chips.First(c => c.Type == ChipType.Red));
            chips.Add(new Chip(ChipType.Green));
        }
        while (chips.Count(c => c.Type == ChipType.Green) >= 10)
        {
            for (int i = 0; i < 10; i++) chips.Remove(chips.First(c => c.Type == ChipType.Green));
            chips.Add(new Chip(ChipType.Black));
        }
    }
}

public class Table : ITable
{
    public List<IPlayer> players { get; } = new();
    public IDeck Deck { get; }
    public List<Chip> Pot { get; } = new();

    public Table(IDeck deck)
    {
        Deck = deck ?? throw new ArgumentNullException(nameof(deck));
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

        // defaults
        _minRaise = 5;
        _bigBlind = 10;
        _smallBlindIndex = 0;
        _bigBlindIndex = 1;
    }
     public void StartGame()
    {
        Console.WriteLine("=== Game Start ===");
        ResetDeck();
        _communityCards.Clear();
        _players.Clear();
        _players.AddRange(_table.players);

        if (_players.Count < 2)
        {
            Console.WriteLine("Tidak cukup pemain untuk memulai (minimal 2).");
            return;
        }

        ResetRound();
        PostBlinds();
        DealCards();
        BettingRounds(); // Pre-flop

        DealCommunityCards(3); BettingRounds(); // Flop
        DealCommunityCards(1); BettingRounds(); // Turn
        DealCommunityCards(1); BettingRounds(); // River

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
        Console.WriteLine("\n-- Dealing hole cards --");
        foreach (var p in _players)
        {
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
            _communityCards.Add(DealCardDeck());
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
        if (_players.Count < 2) return;
        var sb = _players[_smallBlindIndex % _players.Count];
        var bb = _players[_bigBlindIndex % _players.Count];

        int smallAmt = _bigBlind / 2;
        var sbChips = RemoveChipsFromPlayer(sb, smallAmt);
        AddChipsListToPot(sbChips);
        sb.CurrentBet = smallAmt;

        var bbChips = RemoveChipsFromPlayer(bb, _bigBlind);
        AddChipsListToPot(bbChips);
        bb.CurrentBet = _bigBlind;

        _currentBet = _bigBlind;

        Console.WriteLine($"{sb.Name} posts small blind {smallAmt}");
        Console.WriteLine($"{bb.Name} posts big blind {_bigBlind}");
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

            // default Call
            var callChips = RemoveChipsFromPlayer(p, needToCall);
            AddChipsListToPot(callChips);
            p.CurrentBet += callChips.Sum(c => (int)c.Type);
            Console.WriteLine($"{p.Name} calls {needToCall}");
        }
    }
    private void ProcessPlayerTurn(IPlayer player, PlayerAction action)
    {

    }
    private void Showdown()
    {
        Console.WriteLine("\n-- Showdown --");
        List<(IPlayer player, HandResult result)> results = new();

        foreach (var p in _players)
        {
            if (p.IsFolded) continue;

            var playerCards = p.Hand.Cards.ToList();
            HandResult result = EvaluateHand(playerCards, _communityCards);

            results.Add((p, result));

            string holeCards = string.Join(", ", playerCards.Select(c => $"{c.Rank} of {c.Suit}"));

            // Ambil 5 kartu terbaik (rank + suit)
            var allCards = playerCards.Concat(_communityCards).ToList();
            var best5 = GetCombinations(allCards, 5)
                        .Select(combo => EvaluateFiveCardHand(combo))
                        .OrderByDescending(r => r.Strength)
                        .ThenByDescending(r => r.Kickers, Comparer<List<int>>.Create(CompareKickers))
                        .First();

            string kickerNames = string.Join(", ",
                best5.Kickers.Select(v =>
                {
                    // Ambil kartu dengan rank sesuai kicker
                    var card = allCards.FirstOrDefault(c => (int)c.Rank == v);
                    return card != null ? $"{card.Rank} of {card.Suit}" : ((Rank)v).ToString();
                }));

            Console.WriteLine($"{p.Name}: {result.Name} (Strength: {result.Strength})");
            Console.WriteLine($"   Hole Cards : {holeCards}");
            Console.WriteLine($"   Kickers    : {kickerNames}");
        }

        if (results.Count == 0)
        {
            Console.WriteLine("No players in showdown.");
            return;
        }

        // Cari hand terbaik
        int bestStrength = results.Max(r => r.result.Strength);
        var bestCandidates = results.Where(r => r.result.Strength == bestStrength).ToList();

        var winners = new List<IPlayer>();
        HandResult bestResult = bestCandidates[0].result;
        winners.Add(bestCandidates[0].player);

        for (int i = 1; i < bestCandidates.Count; i++)
        {
            int cmp = CompareKickers(bestCandidates[i].result.Kickers, bestResult.Kickers);
            if (cmp > 0)
            {
                winners.Clear();
                winners.Add(bestCandidates[i].player);
                bestResult = bestCandidates[i].result;
            }
            else if (cmp == 0)
            {
                winners.Add(bestCandidates[i].player);
            }
        }

        if (winners.Count == 1)
        {
            Console.WriteLine($"Winner: {winners[0].Name} with {results.First(r => r.player == winners[0]).result.Name}");
            var potChips = _table.Pot.ToList();
            _table.Pot.Clear();
            AddChipsListToPlayer(winners[0], potChips);
        }
        else
        {
            Console.WriteLine("Tie between: " + string.Join(", ", winners.Select(w => w.Name)));
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
        public List<int> Kickers { get; set; } = new(); 

        // helper: konversi ke nama kartu
        public string KickersAsString => string.Join(", ", Kickers.Select(v => ((Rank)v).ToString()));
    }

    private HandResult EvaluateBestHand(List<ICard> cards)
     {
        var allCombos = GetCombinations(cards, 5);
        HandResult best = new HandResult();
        foreach (var combo in allCombos)
        {
            var result = EvaluateFiveCardHand(combo);
            if (result.Strength > best.Strength ||
                (result.Strength == best.Strength && CompareKickers(result.Kickers, best.Kickers) > 0))
                best = result;
        }
        return best;
    }
    private HandResult EvaluateFiveCardHand(List<ICard> cards)
    {
        // Urutkan kartu (tinggi ke rendah)
        var sorted = cards.OrderByDescending(c => c.Rank).ToList();

        // Kelompokkan rank
        var groups = cards.GroupBy(c => c.Rank)
                        .OrderByDescending(g => g.Count())
                        .ThenByDescending(g => g.Key)
                        .ToList();

        // Royal Flush
        if (IsRoyalFlush(cards))
        {
            return new HandResult
            {
                Name = "Royal Flush",
                Strength = GetHandStrength("Royal Flush"),
                Kickers = new List<int> { (int)Rank.Ace, (int)Rank.King, (int)Rank.Queen, (int)Rank.Jack, (int)Rank.Ten }
            };
        }

        // Straight Flush
        if (IsStraightFlush(cards))
        {
            var straightFlush = sorted.Select(c => (int)c.Rank).OrderByDescending(r => r).Take(5).ToList();
            return new HandResult
            {
                Name = "Straight Flush",
                Strength = GetHandStrength("Straight Flush"),
                Kickers = straightFlush
            };
        }

        // Four of a Kind
        if (IsFourOfAKind(cards))
        {
            var quad = groups.First(g => g.Count() == 4).Key;
            var kicker = groups.First(g => g.Count() == 1).Key;
            return new HandResult
            {
                Name = "Four of a Kind",
                Strength = GetHandStrength("Four of a Kind"),
                Kickers = Enumerable.Repeat((int)quad, 4).Concat(new[] { (int)kicker }).ToList()
            };
        }

        // Full House
        if (IsFullHouse(cards))
        {
            var three = groups.First(g => g.Count() == 3).Key;
            var pair = groups.First(g => g.Count() == 2).Key;
            return new HandResult
            {
                Name = "Full House",
                Strength = GetHandStrength("Full House"),
                Kickers = Enumerable.Repeat((int)three, 3).Concat(Enumerable.Repeat((int)pair, 2)).ToList()
            };
        }

        // Flush
        if (IsFlush(cards))
        {
            var flushSuit = cards.GroupBy(c => c.Suit).First(g => g.Count() >= 5).Key;
            var flush5 = cards.Where(c => c.Suit == flushSuit)
                            .OrderByDescending(c => c.Rank)
                            .Take(5)
                            .Select(c => (int)c.Rank)
                            .ToList();

            return new HandResult
            {
                Name = "Flush",
                Strength = GetHandStrength("Flush"),
                Kickers = flush5
            };
        }

        // Straight
        if (IsStraight(cards))
        {
            var ranks = cards.Select(c => (int)c.Rank).Distinct().ToList();
            if (ranks.Contains((int)Rank.Ace)) ranks.Add(1); // Ace low
            ranks = ranks.OrderByDescending(r => r).ToList();

            List<int> straight5 = new();
            for (int i = 0; i < ranks.Count - 4; i++)
            {
                if (ranks[i] - ranks[i + 4] == 4)
                {
                    straight5 = ranks.Skip(i).Take(5).ToList();
                    break;
                }
            }

            return new HandResult
            {
                Name = "Straight",
                Strength = GetHandStrength("Straight"),
                Kickers = straight5
            };
        }

        // Three of a Kind
        if (IsThreeOfAKind(cards))
        {
            var trips = groups.First(g => g.Count() == 3).Key;
            var kickers = groups.Where(g => g.Count() == 1).Select(g => g.Key).OrderByDescending(r => r).Take(2).ToList();
            return new HandResult
            {
                Name = "Three of a Kind",
                Strength = GetHandStrength("Three of a Kind"),
                Kickers = Enumerable.Repeat((int)trips, 3).Concat(kickers.Select(k => (int)k)).ToList()
            };
        }

        // Two Pair
        if (IsTwoPair(cards))
        {
            var pairs = groups.Where(g => g.Count() == 2).Select(g => g.Key).OrderByDescending(r => r).Take(2).ToList();
            var kicker = groups.FirstOrDefault(g => g.Count() == 1)?.Key ?? Rank.Two;
            return new HandResult
            {
                Name = "Two Pair",
                Strength = GetHandStrength("Two Pair"),
                Kickers = Enumerable.Repeat((int)pairs[0], 2)
                        .Concat(Enumerable.Repeat((int)pairs[1], 2))
                        .Concat(new[] { (int)kicker })
                        .ToList()
            };
        }

        // One Pair
        if (IsOnePair(cards))
        {
            var pair = groups.First(g => g.Count() == 2).Key;
            var kickers = groups.Where(g => g.Count() == 1).Select(g => g.Key).OrderByDescending(r => r).Take(3).ToList();
            return new HandResult
            {
                Name = "One Pair",
                Strength = GetHandStrength("One Pair"),
                Kickers = Enumerable.Repeat((int)pair, 2).Concat(kickers.Select(k => (int)k)).ToList()
            };
        }

        // High Card
        var high5 = sorted.Take(5).Select(c => (int)c.Rank).ToList();
        return new HandResult
        {
            Name = $"High Card {((Rank)high5.First()).ToString()}",
            Strength = GetHandStrength("High Card"),
            Kickers = high5
        };
    }

    public IEnumerable<List<ICard>> GetCombinations(List<ICard> cards, int k)
    {
        int n = cards.Count;
        if (k > n) yield break;
        int[] indices = new int[k];
        for (int i = 0; i < k; i++) indices[i] = i;

        while (true)
        {
            yield return indices.Select(i => cards[i]).ToList();
            int t = k - 1;
            while (t >= 0 && indices[t] == n - k + t) t--;
            if (t < 0) yield break;
            indices[t]++;
            for (int i = t + 1; i < k; i++) indices[i] = indices[i - 1] + 1;
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
        "High Card" => 1,
        _ => 1
    };
    private int CompareKickers(List<int> k1, List<int> k2)
    {
        if (k1 == null && k2 == null) return 0;
        if (k1 == null) return -1;
        if (k2 == null) return 1;

        int count = Math.Max(k1.Count, k2.Count);
        for (int i = 0; i < count; i++)
        {
            int v1 = i < k1.Count ? k1[i] : 0;
            int v2 = i < k2.Count ? k2[i] : 0;

            if (v1 > v2) return 1;
            if (v1 < v2) return -1;
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
        if (_table.Deck == null) throw new InvalidOperationException("Table deck is null.");
        _table.Deck.Initialize();
        _table.Deck.Shuffle(_random);
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
            for (int i = 0; i < 5; i++) chips.Remove(chips.First(c => c.Type == ChipType.White));
            chips.Add(new Chip(ChipType.Red));
        }
        // Red -> Green : 2 reds -> 1 green
        while (chips.Count(c => c.Type == ChipType.Red) >= 2)
        {
            for (int i = 0; i < 2; i++) chips.Remove(chips.First(c => c.Type == ChipType.Red));
            chips.Add(new Chip(ChipType.Green));
        }
        // Green -> Black : 10 greens -> 1 black
        while (chips.Count(c => c.Type == ChipType.Green) >= 10)
        {
            for (int i = 0; i < 10; i++) chips.Remove(chips.First(c => c.Type == ChipType.Green));
            chips.Add(new Chip(ChipType.Black));
        }
    }

    private int GetPotValue() =>
        _table.Pot.Sum(c => (int)c.Type);

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
    

