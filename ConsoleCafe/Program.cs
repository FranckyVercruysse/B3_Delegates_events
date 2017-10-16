﻿using LibCafe;
using System;

namespace ConsoleCafe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPints = 10;
            PintDish pintDish = new PintDish(numberOfPints);
            pintDish.PintStarted += PintDish_PintStarted;
            pintDish.PintCompleted += PintDish_PintCompleted;
            pintDish.DishHalfway += PintDish_DishHalfway;
            pintDish.DishCompleted += PintDish_DishCompleted;

            for (int i = 0; i < numberOfPints ; i++)
            {
                try
                {
                    pintDish.AddPint();
                    Console.WriteLine($"Pint {pintDish.PintCount} added\n\n");
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }

        private static void PintDish_DishCompleted(object sender, DishCompletedEventargs e)
        {
            Console.WriteLine($"Dish completed in {e.Ts.TotalMilliseconds} ms, enjoy jour drinks!") ;
        }

        private static void PintDish_DishHalfway(object sender, EventArgs e)
        {
            Console.WriteLine($"Dish halfway, get ready ...");
        }

        private static void PintDish_PintStarted(object sender, EventArgs e)
        {
            Console.WriteLine($"Brewing Pint...");
        }

        private static void PintDish_PintCompleted(object sender, PintCompletedArgs e)
        {
            Console.WriteLine($"{e.Brand} brewed by {e.Waiter}, cheers!");
        }
    }
}
