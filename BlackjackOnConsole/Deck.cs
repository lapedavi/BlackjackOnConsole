using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackOnConsole
{
    internal static class Deck
    {
        private static List<int>? cards;

        private static List<int> Cards
        {
            get
            {
                if(cards == null)
                {
                    InitializeDeck();
                }
                return cards!;
            }
        }

        public static int DrawCard()
        {
            Random rnd = new();
            var index = rnd.Next(0, Cards.Count - 1);
            var card = Cards[index];
            Cards.RemoveAt(index);
            return card;
        }

        public static void InitializeDeck()
        {
            List<int> suite = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10];
            int numberOfSuites = 8;

            List<int> newCards = [];
            for (int i = 0; i < numberOfSuites; i++)
            {
                newCards.AddRange(suite);
            }

            cards = newCards;
        }
    }
}
