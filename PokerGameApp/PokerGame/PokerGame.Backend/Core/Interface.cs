namespace PokerGameApp;
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
    int Balance { get; set; }
    int TotalContributed { get; set; }
}

public interface ITable
{
    List<IPlayer> players { get; }
    IDeck Deck { get; }
    List<Chip> Pot { get; }

    List<ICard> CommunityCards { get; }

    void AddCommunityCard(ICard card);
    void ClearCommunityCards();
}


