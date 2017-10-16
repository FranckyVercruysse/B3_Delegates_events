using LibCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLightSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            LightSwitch lightSwitch = new LightSwitch();
            lightSwitch.LightsOn += LightSwitch_LightsOn;
            lightSwitch.LightsOff += LightSwitch_LightsOff;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    lightSwitch.SwitchLights();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
        }

        private static void LightSwitch_LightsOff(object sender, EventArgs e)
        {
            Console.WriteLine($"Lights are off - all dark");
        }

        private static void LightSwitch_LightsOn(object sender, LightsOnEventArgs e)
        {
            Console.WriteLine($"{e.Color} lights are on");
        }
    }
}
