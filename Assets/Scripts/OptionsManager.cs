using System;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    private AudioManager _audioManager;
    
    public bool mutingAudio = false;


    private void Start()
    {
        // Set up a reference to find the audio manager
        _audioManager = GameManager.Instance.AudioManager;
    }
}
