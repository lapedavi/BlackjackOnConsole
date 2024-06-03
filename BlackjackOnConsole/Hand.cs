using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackOnConsole
{
    internal class Hand
    {
        private List<int> cards;

        public Hand() 
        {
            cards = [ Deck.DrawCard(), Deck.DrawCard()];
        }

        public void DrawCard()
        {
            cards.Add(Deck.DrawCard());
        }

        public int Sum
        {
            get
            {
                var total = cards.Sum();

                if (!cards.Contains(1))
                {
                    return total;
                }

                var totalAs11 = total + 10;

                if(totalAs11 > 21)
                {
                    return total;
                }

                return totalAs11;
            }
        }

        public string Cards
        {
            get
            {
                return string.Join(',', cards);
            }
        }
    }
}
