using UnityEngine;

namespace CursedKnight
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public int cardEnergyCost;
        public string cardDescription;
        public int cardCorruptionGain;
        public CardType cardType;

        public enum CardType
        {
            Attack,
            Defense,
            Utility
        }
    }
}
