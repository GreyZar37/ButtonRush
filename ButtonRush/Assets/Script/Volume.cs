using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{

    public static float volume;
    public TextMesh volumeText;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        audioSource.volume = volume;
        volumeText.text = (volume * 10).ToString("F0") + "/10";
        PlayerPrefs.SetFloat("Volume", volume);
    }

    
}
