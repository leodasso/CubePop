using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Audio;


/// <summary>
/// A scriptable object that's a collection of audio clips. Allows for various similar clips to be grouped together,
/// and when this is invoked, it will pick one at random. Pairs with the AudioAction component
/// </summary>
[CreateAssetMenu]
public class AudioCollection : ScriptableObject
{
    public float volume = 1;
    [MinMaxSlider(.1f, 2, true)]
    public Vector2 pitchRange = new Vector2(1, 1);
    [AssetsOnly]
    public List<AudioClip> clips = new List<AudioClip>();
    public float audioLifetime = 5;

    [DrawWithUnity]
    public AudioMixerGroup mixerGroup;

    public AudioClip GetRandomClip()
    {
        int i = Random.Range(0, clips.Count);
        return clips[i];
    }

    public float Pitch()
    {
        return Random.Range(pitchRange.x, pitchRange.y);
    }
}
