namespace PokerGameApp
{
    public class Table : ITable
    {
        public List<IPlayer> players { get; } = new();
        public IDeck Deck { get; }
        public List<Chip> Pot { get; } = new();

        //Tambahkan: daftar kartu community
        public List<ICard> CommunityCards { get; } = new();

        public Table(IDeck deck)
        {
            Deck = deck ?? throw new ArgumentNullException(nameof(deck));
        }

        //Fungsi untuk mengelola kartu community
        public void AddCommunityCard(ICard card) => CommunityCards.Add(card);
        public void ClearCommunityCards() => CommunityCards.Clear();
    }
}
