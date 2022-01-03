using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{

    public static float volume;
    public TextMesh volumeText;
    public AudioSource audioSource;

    void Start()
    {
        // Gets the volume float from the playerpref 
        volume = PlayerPrefs.GetFloat("Volume", 0.2f);
    }

    void Update()
    {
        // Changes the music volume
        audioSource.volume = volume;
        volumeText.text = (volume * 10).ToString("F0") + "/10";
        // Saves the music volume
        PlayerPrefs.SetFloat("Volume", volume);
    }

    
}
