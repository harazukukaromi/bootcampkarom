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

    public Action<GameEventType>? OnGameEvent;
    public Action<IPlayer, string, int>? OnGameEnded;
    public Func<IPlayer, int, int, PlayerAction>? OnPlayerDecision;

    public PokerGame(ITable table)
    {

    }
    public void StartGame()
    {

    }
    private void PlayRound()
    {

    }
    private void ResetRound()
    {

    }
    private void DealCards()
    {

    }
    private void DealCommunityCards(int count)
    {

    }
    private void PostBlinds()
    {

    }
    private void BettingRounds()
    {

    }
    private void ProcessPlayerTurn(IPlayer player, PlayerAction action)
    {

    }
    private void Showdown()
    {

    }
    private void DistributePot()
    {

    }

    //private string EvaluateBestHand(List<ICard> cards)
    public string EvaluateBestHand(List<ICard> cards)
    {
        // kombinasi 7 kartu (2 hole + 5 community) → pilih kombinasi 5 terbaik
        var allCombos = GetCombinations(cards, 5);

        string bestHand = "High Card";
        int bestStrength = 0;

        foreach (var combo in allCombos)
        {
            string hand = EvaluateFiveCardHand(combo);
            int strength = GetHandStrength(hand);

            if (strength > bestStrength)
            {
                bestStrength = strength;
                bestHand = hand;
            }
        }

        return bestHand;
    }
    private string EvaluateFiveCardHand(List<ICard> cards)
    {
        if (IsRoyalFlush(cards)) return "Royal Flush";
        if (IsStraightFlush(cards)) return "Straight Flush";
        if (IsFourOfAKind(cards)) return "Four of a Kind";
        if (IsFullHouse(cards)) return "Full House";
        if (IsFlush(cards)) return "Flush";
        if (IsStraight(cards)) return "Straight";
        if (IsThreeOfAKind(cards)) return "Three of a Kind";
        if (IsTwoPair(cards)) return "Two Pair";
        if (IsOnePair(cards)) return "One Pair";
        return "High Card";
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
    public string EvaluateHand(List<ICard> handCards, List<ICard> communityCards)
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
    public void AddPlayer(IPlayer player) => _table.players.Add(player);
    public void RemovePlayer(IPlayer player) => _table.players.Remove(player);
    public List<IPlayer> GetPlayers() => _table.players;
    public void AddCard(ICard card) => _communityCards.Add(card);
    public void ClearCard() => _communityCards.Clear();
    public void ResetForNewRound() => ResetRound();
    public bool PlaceBet()
    {
        _currentBet += (int)ChipType.White;
        return true;
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
