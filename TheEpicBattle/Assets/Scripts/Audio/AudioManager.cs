using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager {
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioName, AudioClip> audioClips =
        new Dictionary<AudioName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source) {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioName.AttackEnemy,
            Resources.Load<AudioClip>("AttackEnemy"));
        audioClips.Add(AudioName.AttackPlayer,
            Resources.Load<AudioClip>("AttackPlayer"));
        audioClips.Add(AudioName.Gameover,
            Resources.Load<AudioClip>("Gameover"));
        audioClips.Add(AudioName.Heal,
             Resources.Load<AudioClip>("Heal"));
        audioClips.Add(AudioName.Magic,
              Resources.Load<AudioClip>("Magic"));
        audioClips.Add(AudioName.Menu,
              Resources.Load<AudioClip>("Menu"));
        audioClips.Add(AudioName.Victory,
              Resources.Load<AudioClip>("Victory"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioName name) {
        audioSource.PlayOneShot(audioClips[name]);
    }

    /// <summary>
    /// Stop
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Stop() {
        audioSource.Stop();
    }
}

