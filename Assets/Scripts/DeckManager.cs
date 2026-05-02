using System;
using System.Collections.Generic;
using CursedKnight;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> cardDeck = new List<Card>();
    
    private int _currentCardIndex = 0;

    public void Start()
    {
        // Load all card assets from the Resources folder
        var cards = Resources.LoadAll<Card>("Cards");
        
        // Add the loaded cards to the cardDeck list
        cardDeck.AddRange(cards);
    }

    public void DrawCard(HandManager handManager)
    {
        if (cardDeck.Count == 0) return;
        
        // Look to the next card according to the current index
        // Add that card to our hand while updating the current card index
        var nextCard = cardDeck[_currentCardIndex];
        handManager.AddCardToHand(nextCard);
        _currentCardIndex =  (_currentCardIndex + 1) % cardDeck.Count;
    }
}
