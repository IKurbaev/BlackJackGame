using System;

namespace BlackJackGame
{
    public class Player : Hand
    {
        public string Name {get; private set;}
        byte _score {get; set;}
        bool _dealer = false;

        public Player(string name) => Name = name;
        public Player() => Name = "Player";
        public void NewGame() => _score = 0;
        public string Status()
        {   
            string cards = "";
            foreach (var i in _cardsOnHand)
            {
                cards += i.ShowCardStr() + ' ';
            }
            if (cards == "") {cards += '-';}
            return $"Имя игрока: {Name}, колличество очков: {_score}\nКарты на руках: {cards}";
        }
        public void SetDealer() => _dealer = !_dealer;
        public void ScoreFromCards()
        {   
            char cs = ' ';
            foreach (var i in _cardsOnHand)
            {
                cs = i.ShowCardStr()[1];
                switch (cs)
                {
                    case 'Q':
                        goto case 'K';
                    case 'J':
                        goto case 'K';
                    case 'K':
                        _score += 10;
                        break;
                    case 'A':
                        if (_score <= 10) { _score += 11; }
                        else { _score += 1; }
                        break;
                    default:
                        _score += (byte)cs;
                        break;
                }          
            }
        }
    }
}