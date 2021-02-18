using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck firstDeck = new Deck();
            firstDeck.removeTop();
            Console.WriteLine(firstDeck.cards.Count);
            firstDeck.resetDeck();
            Console.WriteLine(firstDeck.cards.Count);
            firstDeck.shuffleDeck();
            foreach (Card entry in firstDeck.cards)
            {
                Console.WriteLine(entry.stringVal + " of " + entry.suit);
            }
        }
    }

    public class Card
    {
        //field
        public string stringVal { get; set; }
        public string suit { get; set; }
        public int val { get; set; }

        public Card(string name, string type, int value)
        {
            stringVal = name;
            suit = type;
            val = value;
        }
    }
    //--------------------------------------------------------
    public class Deck
    {
        //properties
        public List<Card> cards { get; set; }
        public string[] faceVal = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        public string[] type = new string[] { "Clubs", "Spades", "Hearts", "Diamonds" };
        public int[] numVal = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        //constructor
        public Deck()
        {
            cards = new List<Card>();

            for (int i = 0; i < type.Length; i++)
            {
                for (int j = 0; j < faceVal.Length; j++)
                {
                    Card newCard = new Card(faceVal[j],
                                            type[i],
                                            numVal[j]);
                    cards.Add(newCard);
                }
            }
        }
        //methods
        public Card removeTop()
        {
            if (this.cards == null)
            {
                Console.WriteLine("Out of cards");
                return null;
            }
            else
            {
                Card result = this.cards[0];
                this.cards.Remove(this.cards[0]);
                Console.WriteLine($"{result.stringVal} of {result.val} was removed from the deck");
                return result;
            }
        }

        public List<Card> resetDeck()
        {
            cards.Clear();
            {
                for (int i = 0; i < type.Length; i++)
                {
                    for (int j = 0; j < faceVal.Length; j++)
                    {
                        Card newCard = new Card(faceVal[j],
                                                type[i],
                                                numVal[j]);
                        cards.Add(newCard);
                    }
                }
            }
            shuffleDeck();
            return cards;
        }

        public void shuffleDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int randIdx = rand.Next(0, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randIdx];
                cards[randIdx] = temp;
            }

            Console.WriteLine("Cards are shuffled!");

        }
    }
    //-------------------------------------------
    public class Player
    {
        //properties
        public string name { get; set; }
        public List<Card> hand { get; set; }
        //constructor
        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }
        //methods
        public Card drawCard(Deck deckName)
        {
            if (this.hand.Count > 6)
            {
                Console.WriteLine("Too many cards!");
                return null;
            }
            else
            {
                Card drawnCard;
                drawnCard = deckName.removeTop();
                this.hand.Add(drawnCard);
                return drawnCard;
            }
        }

        public Card discardCard(int idx)
        {
            if (idx > this.hand.Count || idx < 0)
            {
                Console.WriteLine($"That card doesn't exist. You have {this.hand.Count} cards -- pick a number less than that amount.");
                return null;
            }
            else
            {
                Card result = this.hand[idx];
                this.hand.Remove(this.hand[idx]);
                return result;
            }
        }
    }



}
