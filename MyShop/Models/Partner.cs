using System.Text;
using System.Threading;

namespace MyShop.Models
{
    public class Partner
    {
        public StringBuilder Url { get; set; } = new StringBuilder(2000);
        public string DisplayName { get; set; }
        public Partner(string displayName, string url)
        {
            DisplayName = displayName;
            Url.Append(url);
        }
        ~Partner()
        {
            //some long running operation to clean things up
            Thread.Sleep(5000);
        }
    }
}