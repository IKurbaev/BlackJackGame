using System.Collections.Generic;
using System;

namespace BlackJackGame
{
    public class Deck
    {
        string _values = "A23456789XJQK";
        string _suits = "shdc";
        List<Card> _cardsInDeck = new List<Card>();
        public Deck()
        {   
            foreach (var i in _suits)
            {
                foreach (var j in _values)
                {
                    if (j == 'X')
                        _cardsInDeck.Add(new Card($"{i}10"));
                    else
                        _cardsInDeck.Add(new Card($"{i}{j}"));    
                }
            }
        }

        public void ShowFullDeck()
        {
            Console.Write("\n{");
            Console.Write(' ');
            foreach (var i in _cardsInDeck)
            {
                i.Flip();
                i.ShowCard();
                Console.Write(' ');
                i.Flip();
            }
            Console.WriteLine('}');
        }

        public void Shufle()
        {
            Random r = new Random();
            List<Card> newList = new List<Card>();
            
            while (_cardsInDeck.Count() != 0)
            {
                int rnum = r.Next(0, _cardsInDeck.Count());
                newList.Add(_cardsInDeck[rnum]);
                _cardsInDeck.RemoveAt(rnum);
            }

            _cardsInDeck = newList;
        }

        public Card TakeForPlayer()
        {
            Card _temp = _cardsInDeck[_cardsInDeck.Count()-1];
            _cardsInDeck.RemoveAt(_cardsInDeck.Count()-1);
            return _temp;
        }

        public void PutInDeck(Card c) => _cardsInDeck.Add(c);
    }
}
