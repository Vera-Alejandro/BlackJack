﻿using Blackjack.Data.Enums;

using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Blackjack.Data
{
    public class Card
    {
        private string _cardImg { get; set; }
        private string _cardBack { get; set; }
        private string Name { get; set; }
        public CardValue CardValue { get; private set; }
        private SuiteType _suit { get; set; }
        private bool _beenUsed { get; set; }

        public Card( CardValue cardValue, SuiteType suitType )
        {
            string pathtoCertCard;
            string pathToCardDir = @"Blackjack.Data\Resources\card_images";
            string baseCardDir = 
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetParent(
                            Directory.GetParent(
                                Directory.GetCurrentDirectory()
                            ).FullName
                        ).FullName
                    ).FullName
                ).FullName;
            string cardImgDir = Path.Combine(baseCardDir, pathToCardDir );

            CardValue = cardValue;
            _suit = suitType;
            _beenUsed = false;
          
            foreach (var suit in Enum.GetValues( typeof( SuiteType ) ))

            {
                foreach (var value in Enum.GetValues( typeof( CardValue ) ))
                {
                    pathtoCertCard = @$"{suit}\{value} of {suit}.png";
                    this._cardImg = Path.Combine(cardImgDir, pathtoCertCard);
                    pathtoCertCard = string.Empty;
                }
            }

            _cardBack = Path.Combine( cardImgDir, "Card Back.png");
        }

        public int GetCardValue()
        {
            if (CardValue == CardValue.Ace)
            {
                return 11;
            }

            int numValue = (int) CardValue;

            if (numValue > 10)
            {
                return 10;
            }

            return numValue;
        }

        public void SetCardValue( CardValue Value ) => CardValue = Value;

        public SuiteType SuiteType => _suit;

        public void SetSuitType( SuiteType Suit ) => _suit = Suit;

        public bool UsedValue => _beenUsed;

        public void SetUsedValue( bool SetCase ) => _beenUsed = SetCase;

        public SuiteType SuiteType1 => _suit;

        public string ImagePath
            => _cardImg;

        public string BackImagePath

            => _cardBack;

        public void SetImage( string CardImage ) => _cardImg = CardImage;

    }
}