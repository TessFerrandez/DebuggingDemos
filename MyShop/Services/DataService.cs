using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Services
{
    public class DataService
    {
        public List<Partner> GetAllPartners()
        {
            List<Partner> partners = new List<Partner>();
            partners.Add(new Partner("Debugging tools", "http://www.microsoft.com/whdc/devtools/debugging/default.mspx"));
            partners.Add(new Partner("If broken it is, fix it you should", "http://blogs.msdn.com/Tess"));
            partners.Add(new Partner("Speaking of which...", "http://blogs.msdn.com/johan"));
            partners.Add(new Partner("A developers stayings", "http://blogs.msdn.com/carloc"));
            partners.Add(new Partner("Notes from a dark corner", "http://blogs.msdn.com/dougste"));
            partners.Add(new Partner("Cheshire's blog", "http://blogs.msdn.com/jamesche"));
            partners.Add(new Partner("ASP.NET debugging", "http://blogs.msdn.com/tom"));
            partners.Add(new Partner("Nico's weblog", "http://blogs.msdn.com/nicd"));
            partners.Add(new Partner("Todd Carter's weblog", "http://blogs.msdn.com/toddca"));
            return partners;
        }
        internal List<Product> GetOrder()
        {
            return AllProducts.Take(3).ToList();
        }
        public List<Product> GetAllProducts(bool slow)
        {
            //fake a long running query
            if (slow)
                Task.Delay(2000).Wait();

            return AllProducts.ToList();
        }
        public Review GetReview()
        {
            Random r = new Random();
            int index = r.Next(3);

            if (index == 0)
            {
                return new Review
                {
                    Quote = "Buggy Bits is the best thing since sliced bread",
                    Source = "The bug observer"
                };
            }
            else if (index == 1)
            {
                return new Review
                {
                    Quote = "I have never seen such buggy bits, Buggy Bits are truly breaking new ground",
                    Source = "Bug Magazine"
                };
            }
            else
            {
                return new Review
                {
                    Quote = "Once you have start using Buggy Bits there is no going back",
                    Source = "Bug Chronicles"
                };
            }
        }
        #region statics
        public static Product[] AllProducts = new Product[]
        {
            new Product
            {
                Name = "Get out of meeting free card",
                Description = "May be kept until needed or sold",
                Image = "/Assets/card.png",
                Price = 500.00
            },
            new Product
            {
                Name = "Solitaire cheat kit",
                Description = "Tired of not being able to finish your spider solitaire? this is the kit for you",
                Image = "/Assets/solitaire.jpg",
                Price = 4999.99
            },
            new Product
            {
                Name = "Bugspray",
                Description = "Why use a debugger when you can use bugspray?",
                Image = "/Assets/spray.jpg",
                Price = 250.99
            },
            new Product
            {
                Name = "In case of emergency button",
                Description = "Excellent for any type of emergency",
                Image = "/Assets/button.jpg",
                Price = 1.00
            },
            new Product
            {
                Name = "Vanity plate",
                Description = "Now available in 3 different colors and 5 different shapes",
                Image = "/Assets/vanity.jpg",
                Price = 33.00
            },
            new Product
            {
                Name = "w00t baseball cap",
                Description = "Nothing will scare the other team as much as a w00t cap",
                Image = "/Assets/cap.jpg",
                Price = 345.00
            },
            new Product
            {
                Name = "Extra base",
                Description = "Are all your base belong to us? Purchase extra base upgrade",
                Image = "/Assets/base.jpg",
                Price = 22.00
            }
        };
        #endregion 
    }
}