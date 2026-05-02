using UnityEngine;
using CursedKnight;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    // Fields that will be updated depending on what Card is being drawn
    public Card cardData;
    
    // Future Use
    // public Image cardSprite; 
    
    public TMP_Text cardName;
    public TMP_Text cardEnergyCost;
    public TMP_Text cardDescription;
    public TMP_Text cardCorruptionGain;
    public TMP_Text cardType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCardDisplay();
    }
    // Updates all card data populated by each card in player's hand/deck
    private void UpdateCardDisplay()
    {
        cardName.text = cardData.name;
        cardEnergyCost.text = cardData.cardEnergyCost.ToString();
        cardDescription.text = cardData.cardDescription;
        cardCorruptionGain.text = cardData.cardCorruptionGain.ToString();
        cardType.text = cardData.cardType.ToString();

        // Future use
        // cardSprite = cardData.cardSprite;
    }
}
