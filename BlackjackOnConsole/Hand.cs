using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackOnConsole
{
    internal class Hand
    {
        private readonly List<int> _cards;
        private readonly string _owner;

        public Hand(string owner) 
        {
            _cards = [ Deck.DrawCard(), Deck.DrawCard()];
            _owner = owner;
        }

        public void DrawCard()
        {
            _cards.Add(Deck.DrawCard());
        }

        public int Sum
        {
            get
            {
                var total = _cards.Sum();

                if (!_cards.Contains(1))
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

        private string Cards
        {
            get
            {
                return string.Join(',', _cards);
            }
        }

        public override string ToString()
        {
            return $"{_owner} ({Sum}): {Cards}";
        }
    }
}
