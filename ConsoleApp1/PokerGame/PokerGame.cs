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
/*public class PokerGame
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

}*/

