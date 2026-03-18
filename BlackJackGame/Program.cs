

namespace BlackJackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck52 = new Deck();
            deck52.ShowFullDeck();
            deck52.Shufle();
            Console.WriteLine();
            deck52.ShowFullDeck();
            var c = deck52.TakeForPlayer();
            Console.WriteLine($"Из колоды взята карта:");
            c.Flip();
            c.ShowCard();
            deck52.ShowFullDeck();
        }
    }
}