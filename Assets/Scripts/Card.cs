using System.Collections.Generic;
using UnityEngine;

namespace CursedKnight
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public string cardDescription;
       
        public CardType cardType;
        
        public Sprite cardSprite;
        
        public int cardEnergyCost;
        public int cardCorruptionGain;
        public int cardDamage;
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
