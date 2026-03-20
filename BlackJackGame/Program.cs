using System;
using System.Security.Cryptography.X509Certificates;

namespace BlackJackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true, playersMove = true;
            Random r = new Random();
            int aimoves = 1;
            Deck deck = new Deck();
            Player userPlayer = new Player();
            Player aiPlayer = new Player("Дилер");
            while (loop)
            {
                Welcome();
                string? user = Console.ReadLine();

                if (user != null)
                {
                    userPlayer.ChangeName(user);
                    Console.WriteLine("Игра началась");
                    deck.Shufle();
                    userPlayer.Add(deck.TakeForPlayer());
                    userPlayer.Add(deck.TakeForPlayer());
                    aiPlayer.Add(deck.TakeForPlayer());
                    aiPlayer.Add(deck.TakeForPlayer());
                    aimoves = r.Next(0, 3);
                }
                else
                {
                    loop = false;
                }
                
                while (playersMove && (userPlayer._score <= 21))
                {
                    Console.WriteLine(userPlayer.Status());
                    Console.WriteLine(aiPlayer.Status());
                    Console.WriteLine("Вы хотите взять еще карту?(Да\\Нет)\n");
                    user = Console.ReadLine();
                    if (user != null)
                    {
                        if (user.ToLower() == "да")
                        {
                            userPlayer.Add(deck.TakeForPlayer());
                        }
                        if (user.ToLower() == "нет")
                        {
                            playersMove = false;
                        }
                    }      
                }
                if (userPlayer._score > 21)
                {
                    Console.WriteLine($"Игрок {userPlayer.Name} перебрал");
                }
                if (aiPlayer._score > 21)
                {
                    Console.WriteLine($"Игрок {aiPlayer.Name} перебрал");
                }
                else
                {
                   while ((aiPlayer._score < userPlayer._score) && (aiPlayer._score <= 21) && (aimoves > 0))
                    {
                        aiPlayer.Add(deck.TakeForPlayer());
                        aimoves--;
                    } 
                }
                Console.WriteLine(userPlayer.Status());
                Console.WriteLine(aiPlayer.Status());
                if ((userPlayer._score > aiPlayer._score && userPlayer._score <= 21) || aiPlayer._score > 21)
                {
                    Console.WriteLine($"Игрок {userPlayer.Name} выиграл!!!");
                }
                else
                {
                    Console.WriteLine($"Дилер выиграл!");
                }
                loop = false;
                Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
                Console.ReadKey();
            }
        }
        static void Welcome()
        {
            Console.WriteLine("\t\tДобро пожаловать в игру Блэкджек! (ver 0.0.1)");
            Console.WriteLine("\t\tMade by ikurus");
            Console.WriteLine("Введите ваше имя: \n");
        }
    }
}