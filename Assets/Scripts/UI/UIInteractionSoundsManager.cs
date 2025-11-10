using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.EventSystems.EventTrigger;
using Object = UnityEngine.Object;

public class UIInteractionSoundsManager : MonoBehaviour
{
    [Serializable]
    public class SoundFeedback
    {
        public InteractionSoundType soundType;
        public AudioClip soundClip;
    }

    [Header("Feedback List")]
    public List<SoundFeedback> soundFeedbacks = new List<SoundFeedback>();

    [Header("Audio Setup")]
    public AudioSource audioSource;
    public AudioMixerGroup audioMixerGroup;

    private Dictionary<InteractionSoundType, AudioClip> _soundFeedbacksDictionary = new Dictionary<InteractionSoundType, AudioClip>();

    private void Reset()
    {
        //on being added to object, adds each type of sound from enum to list
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        foreach (InteractionSoundType soundType in Enum.GetValues(typeof(InteractionSoundType)))
        {
            soundFeedbacks.Add(new SoundFeedback { soundType = soundType, soundClip = null });
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var entry in soundFeedbacks) { _soundFeedbacksDictionary.Add(entry.soundType, entry.soundClip); }
    }

    public void PlaySound (InteractionSoundType soundType, Object senderObject)
    {
        if (!_soundFeedbacksDictionary.TryGetValue(soundType, out var soundClip))
        {
            Debug.LogWarning($"Sound for {soundType} not found!", senderObject);
            return;
        }
        if (soundClip = null)
        {
            Debug.Log($"No sound clip detected!", senderObject);
            return;
        }

        if (soundType == InteractionSoundType.Unspecified)
            Debug.Log($"{senderObject} plays an unspecified sound.", senderObject);

        if (audioSource != null)
            audioSource.PlayOneShot(soundClip);
    }

    
}
