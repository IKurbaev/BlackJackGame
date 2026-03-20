using System;

namespace BlackJackGame
{
    public class Player : Hand
    {
        public string Name {get; private set;}
        public byte _score {get; private set;}
        public bool _dealer {get; set;}

        public Player(string name)
        {
            _dealer = false;
            _score = 0;
            Name = name;
        }
        public Player()
        {
            Name = "Player";
            _score = 0;
            _dealer = false;
        }     
        public override void Add(Card c)
        {   
            c.Flip();
            base.Add(c);
            ScoreForCard(c);
        }
        public override void FlipOneCard(int numOfCard)
        {
            base.FlipOneCard(numOfCard);
            _score = 0;
            foreach (var i in _cardsOnHand)
            {
                ScoreForCard(i);
            }
        }
        public override void Clear()
        {
            base.Clear();
            _score = 0;
        }
        public void ChangeName(string newname)
        {
            Name = newname;
        }
        public string Status()
        {   
            string cards = "";
            foreach (var i in _cardsOnHand)
            {
                cards += i.ToString() + ' ';
            }
            if (cards == "") {cards += '-';}
            return $"Имя игрока: {Name}, колличество очков: {_score}\nКарты на руках: {cards}";
        }
        void UpdateScore()
        {
            _score = 0;
            foreach (var i in _cardsOnHand)
            {
                ScoreForCard(i);
            }
        }
        void ScoreForCard (Card c)
        {
            string card = c.ToString();
            string score = ""+c.ToString()[1];
            switch (score)
                {
                    case "Q":
                        goto case "K";
                    case "J":
                        goto case "K";
                    case "K":
                        _score += 10;
                        break;
                    case "A":
                        if (_score <= 10) { _score += 11; }
                        else { _score += 1; }
                        break;
                    case "X":
                        _score += 0;
                        break;
                    default:
                        if (char.IsNumber(card[1]))
                        {
                            if (card.Length == 3) { _score += 10; }
                            else { _score += Convert.ToByte(score); }
                        }
                        break;
                }
        }
        public void SetDealer() => _dealer = !_dealer;
    }
}