using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ThePresidents.Models
{
    public class President
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string PresidentNumber { get; set; }
        public string YearsInOffice { get; set; }
        public string Party { get; set; }
        public string State { get; set; }
        public string VP { get; set; }
        public string Summary { get; set; }
        //public Uri Image { get; set; }
        public string Image { get; set; }
        //public ImageSource ImageSource
        //{
        //    get
        //    {
        //        return new BitmapImage(this.Image);
        //    }
        //}
        public string AutomationImageName
        {
            get
            {
                return "Picture of " + FullName;
            }
        }
        public int TermLength
        {
            get
            {
                int dashPos = YearsInOffice.IndexOf('-');
                if (dashPos == -1) return 1;
                string start = YearsInOffice.Substring(0, dashPos);
                string end = YearsInOffice.Substring(dashPos + 1, 4);
                int result = int.Parse(end) - int.Parse(start);
                return result;
            }
        }
        public string YearsInParens
        {
            get
            {
                string result = "";
                int spacePos = YearsInOffice.IndexOf(' ');
                if (spacePos == -1)
                    result = YearsInOffice;
                else
                    result = YearsInOffice.Substring(0, spacePos);
                result = "(" + result + ")";
                return result;
            }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
