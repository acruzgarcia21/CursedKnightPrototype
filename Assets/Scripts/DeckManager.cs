using System;
using System.Collections.Generic;
using CursedKnight;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();

    public int startingHandSize = 6;

    private int _currentIndex = 0;
    public int maxHandSize;
    public int currentHandSize;
    private HandManager _handManager;

    private void Start()
    {
        // Load all card assets from the Resources folder
        var cards = Resources.LoadAll<Card>("Cards");

        // Add the loaded cards to the allCards list
        allCards.AddRange(cards);

        _handManager = FindFirstObjectByType<HandManager>();
        maxHandSize = _handManager.maxCardsInHand;
        for (var i = 0; i < startingHandSize; i++)
        {
            Debug.Log($"Drawing Card");
            DrawCard(_handManager);
        }
    }

    private void Update()
    {
        if (_handManager != null)
        {
            currentHandSize = _handManager.cardsInHand.Count;
        }
    }

    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0) return;
        if (currentHandSize >= maxHandSize) return;
        
        var nextCard = allCards[_currentIndex];
        handManager.AddCardToHand(nextCard);
        _currentIndex = (_currentIndex + 1) % allCards.Count;
    }
}
