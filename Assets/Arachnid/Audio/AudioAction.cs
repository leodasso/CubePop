using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AudioAction : MonoBehaviour
{
	[AssetsOnly]
	public AudioCollection audioCollection;

	[ToggleLeft]
	public bool playOnAwake = false;

	static GameObject _audioParent;

	static GameObject AudioParent()
	{
		if (_audioParent) return _audioParent;
		_audioParent = new GameObject("Audio");
		return _audioParent;
	}	

	// Use this for initialization
	void Start () 
	{
		if (playOnAwake) Play();
	}

	[Button]
	public void Play()
	{
		if (audioCollection == null)
		{
			Debug.LogWarning(name + " has no audio connection referenced!");
			return;
		}
		
		GameObject audioGO = new GameObject(audioCollection.name);
		audioGO.transform.parent = AudioParent().transform;
		AudioSource newSource = audioGO.AddComponent<AudioSource>();
		newSource.clip = audioCollection.GetRandomClip();
		newSource.playOnAwake = false;
		newSource.outputAudioMixerGroup = audioCollection.mixerGroup;
		newSource.volume = audioCollection.volume;
		newSource.pitch = audioCollection.Pitch();
		
		newSource.Play();
		Destroy(audioGO, audioCollection.audioLifetime);
	}
}
