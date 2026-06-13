using System.Collections.Generic;
using UnityEngine;

namespace CursedKnight
{
    public class Card : ScriptableObject
    {
        public string cardName;
        public string cardDescription;
        public CardType cardType;
        public Sprite cardSprite;
        
        public int cardEnergyCost;
        public int cardCorruptionGain;
        public int cardHealth;
        public int cardBlock;

        public enum CardType
        {
            Attack,
            Defense,
            Utility
        }
    }
}
