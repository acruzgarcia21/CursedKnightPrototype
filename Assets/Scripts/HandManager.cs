using System.Collections.Generic;
using UnityEngine;
using CursedKnight;

public class HandManager : MonoBehaviour
{
    // Assign Card Prefab In Inspector
    public GameObject cardPrefab;
    // Root of the Hand Position
    public Transform handTransform;
    // Determines how much our hand will be spread out
    public float fanSpread = 5f;
    // Hold a list of card objects in player's hand
    public List<GameObject> cardsInHand = new List<GameObject>();
    
    void Start()
    {
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
    }

    public void AddCardToHand()
    {
        // Instantiate card
        // 1. GameObject
        // 2. GameObject Position
        // 3. GameObject Rotation (Quaternion.identity = no rotation)
        // 4. Transform Parent
        var newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        UpdateHandVisuals();
    }

    public void UpdateHandVisuals()
    {
        var cardCount = cardsInHand.Count;
        for (var i = 0; i < cardCount; i++)
        {
            // Goes through every single card and goes through each rotation
            var rotationAngle = (fanSpread * (i - (cardCount - 1) / 2f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }
    }
}
