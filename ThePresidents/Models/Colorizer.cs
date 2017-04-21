using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ThePresidents.Models
{
    public class Colorizer
    {
        private static Random rand = new Random(System.DateTime.Now.Millisecond);

        public static SolidColorBrush GetColor(string party)
        {
            var index = rand.Next(10);
            if (index < 2)
                Task.Delay(500).Wait();

            if (party == "Democratic" || party == "Democrat")
                return new SolidColorBrush(Colors.Blue);
            if (party == "Republican")
                return new SolidColorBrush(Colors.Red);
            if (party == "Whig" || party == "Whig and Independent")
                return new SolidColorBrush(Colors.Orange);
            if (party == "Democratic-Republican")
                return new SolidColorBrush(Colors.Purple);
            if (party == "Federalist")
                return new SolidColorBrush(Colors.Maroon);
            return new SolidColorBrush(Colors.Black);
        }
    }
}
