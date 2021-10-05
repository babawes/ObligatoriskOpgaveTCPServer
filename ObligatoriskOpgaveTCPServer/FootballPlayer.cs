using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveTCPServer
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ShirtNumber { get; set; }

        public FootballPlayer(int id, string name, int price, int shirtNumber)
        {
            if (name == "" || name == null)
            {
                throw new ArgumentNullException("Name");
            }

            if (name.Length < 4)
            {
                throw new ArgumentOutOfRangeException("Name");
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price");
            }

            if (shirtNumber < 1 || shirtNumber > 100)
            {
                throw new ArgumentOutOfRangeException("ShirtNumber");
            }

            Id = id;
            Name = name;
            Price = price;
            ShirtNumber = shirtNumber;


        }
    }
}
