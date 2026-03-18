namespace BlackJackGame
{
    public class Card
    {
        bool _fliped = true;
        string _cardValue;
        public Card(string v)
        {
            _cardValue = v;
        }

        public void ShowCard()
        {
            if (_fliped)
                Console.Write("XX");
            else
                Console.Write(_cardValue);
        }
        public void Flip()
        {
            _fliped = !_fliped;
        }
    }
}