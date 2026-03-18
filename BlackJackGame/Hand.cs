using System.Collections.Generic;

namespace BlackJackGame
{
    public class Hand
    {
        protected List<Card> _cardsOnHand;
        public Hand() => _cardsOnHand = new List<Card>();
        public void UnflipOneCard(int numOfCard) => _cardsOnHand[numOfCard-1].Flip();
        public void Add(Card c) => _cardsOnHand.Add(c);
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