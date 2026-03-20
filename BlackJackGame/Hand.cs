using System.Collections.Generic;

namespace BlackJackGame
{
    public class Hand
    {
        protected List<Card> _cardsOnHand;
        public Hand() => _cardsOnHand = new List<Card>();
        public virtual void FlipOneCard(int numOfCard) => _cardsOnHand[numOfCard-1].Flip();
        public virtual void Add(Card c) => _cardsOnHand.Add(c);
        public virtual void Clear() => _cardsOnHand.Clear();
        public void Del(Card c) => _cardsOnHand.Remove(c);
        public void ShowHand()
        {
            foreach (var i in _cardsOnHand)
            {
                i.ShowCard();
            }
        }
    }
}