using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.card
{
    public class Card
    {
        public string CardPIN { get; set; } = "0000";
        public string CardNumber { get; set;} = "0000000000000000";
        public string CardExpiryDate { get; set; } = DateTime.Now.AddYears(5).ToString("MM/yy");

        public Card(string cardPIN, string cardNumber, string cardExpiryDate)
        {
            CardPIN = cardPIN;
            CardNumber = cardNumber;
            CardExpiryDate = cardExpiryDate;
        }
    }
}