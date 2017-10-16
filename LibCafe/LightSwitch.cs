using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void LightsOnHandler(object sender, LightsOnEventArgs e);
    public delegate void LightsOffHandler(object sender, EventArgs e);

    public class LightSwitch
    {
        public event LightsOnHandler LightsOn;
        public event LightsOffHandler LightsOff;

        private bool lightOn=false;

        public void SwitchLights()
        {
            lightOn = !lightOn;
            if (lightOn)
            {
                LightsOn?.Invoke(this, new LightsOnEventArgs());
            }
            else
            {
                LightsOff?.Invoke(this, EventArgs.Empty);
            }
            
        }

    }

    public class LightsOnEventArgs : EventArgs
    {
        private static string[] Colors = { "Red", "Blue", "Green", "White" };
        public static Random random = new Random();

        public string Color { get; }

        public LightsOnEventArgs()
        {
            Color= Colors[random.Next(0, Colors.Length)];
        }
    }

}
