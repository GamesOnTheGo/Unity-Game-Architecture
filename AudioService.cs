using UnityEngine;

/// <summary>
/// Manages audio playback for background music and sound effects in the game.
/// Ensures centralized control of audio resources to easily adjust sound globally.
/// </summary>
public class AudioService : Singleton<AudioService>
{
    private AudioSource musicSource;  // Source for background music
    private AudioSource sfxSource;    // Source for sound effects

    /// <summary>
    /// Initializes audio sources for music and sound effects.
    /// </summary>
    private void Awake()
    {
        musicSource = gameObject.AddComponent<AudioSource>(); // For background music
        sfxSource = gameObject.AddComponent<AudioSource>();   // For sound effects
    }

    /// <summary>
    /// Plays background music, with optional looping.
    /// </summary>
    public void PlayMusic(AudioClip musicClip, bool loop = true)
    {
        if (musicSource.isPlaying)
            musicSource.Stop();

        musicSource.clip = musicClip; // Assign music clip
        musicSource.loop = loop;      // Set looping
        musicSource.Play();           // Start playback
    }

    /// <summary>
    /// Plays a one-shot sound effect.
    /// </summary>
    public void PlaySound(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip); // Play the sound effect once
    }

    /// <summary>
    /// Mutes or unmutes all game audio.
    /// </summary>
    public void ToggleMute(bool isMuted)
    {
        musicSource.mute = isMuted;
        sfxSource.mute = isMuted;
    }
}
