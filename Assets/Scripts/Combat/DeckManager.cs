using System.Collections.Generic;
using CursedKnight;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    
    public int maxHandSize = 10;
    
    private HandManager _handManager;
    private DrawPileManager _drawPileManager;

    private void Awake()
    {
        if (_drawPileManager == null)
        {
            _drawPileManager = FindFirstObjectByType<DrawPileManager>();
        }

        if (_handManager == null)
        {
            _handManager = FindFirstObjectByType<HandManager>();
        }
    }
    
    public void BattleSetup()
    {
        // Load all card assets from the Resources folder
        var cards = Resources.LoadAll<Card>("Cards");

        // Add the loaded cards to the allCards list
        allCards.AddRange(cards);
        
        _handManager.BattleSetup(maxHandSize);
        _drawPileManager.MakeDrawPile(allCards);
    }
}
