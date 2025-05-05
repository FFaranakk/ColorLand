using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // Reference to the music AudioSource
    [SerializeField] private AudioSource SFXSource;   // Reference to the SFX AudioSource

    public AudioClip background; // Reference to the background music clip

    private void Start() // Corrected method name and removed invalid modifier
    {
        musicSource.clip = background;
        musicSource.Play(); // Corrected method name to 'Play' (capitalized)
    }
}