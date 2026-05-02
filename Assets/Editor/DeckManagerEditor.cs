#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DeckManager))]
public class DeckManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DeckManager deckManager = (DeckManager)target;

        if (GUILayout.Button("Draw Next Card"))
        {
            HandManager handManager = Object.FindFirstObjectByType<HandManager>();

            if (handManager != null)
            {
                deckManager.DrawCard(handManager);
            }
            else
            {
                Debug.LogWarning("No HandManager found in the scene.");
            }
        }
    }
}
#endif