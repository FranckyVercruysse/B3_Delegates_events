using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void PintStartedHandler(object sender, EventArgs e);
    public delegate void PintCompletedHandler(object sender, PintCompletedArgs e);

    public delegate void PintDishHalfwayHandler(object sender, EventArgs e);
    public delegate void PintDishCompletedHandler(object sender, DishCompletedEventargs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public event PintCompletedHandler PintCompleted;
        public event PintDishHalfwayHandler DishHalfway;
        public event PintDishCompletedHandler DishCompleted;


        Stopwatch stopWatch= new Stopwatch();
        

        private int pintCount;

        public int PintCount { get { return pintCount; } } // c#6.0 enkel get in property: set enkel in constructor
        public int MaxPints { get; }

        int dishHalfwayPints;

        public PintDish(int maxPints)
        {
            stopWatch.Start();
            MaxPints = maxPints;
            dishHalfwayPints = maxPints / 2 + maxPints % 2;
        }

        


        public void AddPint()
        {
            if (pintCount >= MaxPints) throw new Exception("Dish full, order cancelled");
            PintStarted?.Invoke(this, EventArgs.Empty);
            pintCount++;

            if (pintCount == dishHalfwayPints) DishHalfway?.Invoke(this, EventArgs.Empty);
            if (pintCount == MaxPints)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                DishCompleted?.Invoke(this, new DishCompletedEventargs(ts));
            }
                

            PintCompleted?.Invoke(this, new PintCompletedArgs());
        }
    }


    public class PintCompletedArgs : EventArgs
    {
        private static string[] Brands = { "Cara Pils", "Jupiler", "Stella Artois", "Bavik" };
        private static string[] Waiters = { "Jeff", "Carine", "Billy", "Julie" };
        public static Random random = new Random();

        public string Brand { get; }
        public string Waiter { get; }

        public PintCompletedArgs()
        {
            Brand = Brands[random.Next(0, Brands.Length)];
            Waiter = Waiters[random.Next(0, Waiters.Length)];
        }
    }

    public class DishCompletedEventargs : EventArgs
    {
        public TimeSpan Ts { get; }
        
        public DishCompletedEventargs(TimeSpan ts)
        {
            Ts = ts;
        }
    }
}
