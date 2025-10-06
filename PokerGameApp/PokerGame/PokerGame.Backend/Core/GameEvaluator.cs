using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameApp
{
    public static class GameEvaluator
    {
        public static HandRank EvaluateHand(IEnumerable<ICard> hand)
        {
            var cards = hand.ToList();
            if (cards.Count != 5)
                throw new ArgumentException("Hand harus berisi 5 kartu.");

            var ranks = cards.Select(c => (int)c.Rank).OrderByDescending(x => x).ToList();
            bool isFlush = IsFlush(cards);
            bool isStraight = IsStraight(ranks);

            if (isStraight && isFlush)
                return HandRank.StraightFlush;
            if (IsFourOfAKind(ranks))
                return HandRank.FourOfAKind;
            if (IsFullHouse(ranks))
                return HandRank.FullHouse;
            if (isFlush)
                return HandRank.Flush;
            if (isStraight)
                return HandRank.Straight;
            if (IsThreeOfAKind(ranks))
                return HandRank.ThreeOfAKind;
            if (IsTwoPair(ranks))
                return HandRank.TwoPair;
            if (IsOnePair(ranks))
                return HandRank.OnePair;
            return HandRank.HighCard;
        }

        public static bool IsFlush(IEnumerable<ICard> cards)
        {
            return cards.Select(c => c.Suit).Distinct().Count() == 1;
        }

        public static bool IsStraight(List<int> ranks)
        {
            // Handling Ace-low straight (A-2-3-4-5)
            if (ranks.SequenceEqual(new List<int> { 14, 5, 4, 3, 2 }))
                return true;

            for (int i = 0; i < ranks.Count - 1; i++)
            {
                if (ranks[i] - 1 != ranks[i + 1])
                    return false;
            }
            return true;
        }

        public static bool IsFourOfAKind(List<int> ranks)
        {
            return ranks.GroupBy(r => r).Any(g => g.Count() == 4);
        }

        public static bool IsFullHouse(List<int> ranks)
        {
            return ranks.GroupBy(r => r).Any(g => g.Count() == 3)
                && ranks.GroupBy(r => r).Any(g => g.Count() == 2);
        }

        public static bool IsThreeOfAKind(List<int> ranks)
        {
            return ranks.GroupBy(r => r).Any(g => g.Count() == 3)
                && !IsFullHouse(ranks);
        }

        public static bool IsTwoPair(List<int> ranks)
        {
            return ranks.GroupBy(r => r).Count(g => g.Count() == 2) == 2;
        }

        public static bool IsOnePair(List<int> ranks)
        {
            return ranks.GroupBy(r => r).Count(g => g.Count() == 2) == 1;
        }

        public static int CompareHands(IEnumerable<ICard> handA, IEnumerable<ICard> handB)
        {
            var rankA = EvaluateHand(handA);
            var rankB = EvaluateHand(handB);

            if (rankA != rankB)
                return rankA.CompareTo(rankB);

            // Jika sama → bandingkan kicker (nilai tertinggi)
            var sortedA = handA.Select(c => (int)c.Rank).OrderByDescending(x => x).ToList();
            var sortedB = handB.Select(c => (int)c.Rank).OrderByDescending(x => x).ToList();

            for (int i = 0; i < sortedA.Count; i++)
            {
                if (sortedA[i] > sortedB[i]) return 1;
                if (sortedA[i] < sortedB[i]) return -1;
            }

            return 0; // Seri
        }

        public static string DescribeHand(HandRank rank)
        {
            return rank switch
            {
                HandRank.StraightFlush => "Straight Flush",
                HandRank.FourOfAKind => "Four of a Kind",
                HandRank.FullHouse => "Full House",
                HandRank.Flush => "Flush",
                HandRank.Straight => "Straight",
                HandRank.ThreeOfAKind => "Three of a Kind",
                HandRank.TwoPair => "Two Pair",
                HandRank.OnePair => "One Pair",
                _ => "High Card"
            };
        }
    }

    public enum HandRank
    {
        HighCard = 1,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush
    }
}

