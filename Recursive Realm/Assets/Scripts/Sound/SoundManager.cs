using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public static AudioMixerGroup AudioMixerMaster;
    private void Start()
    {
        AudioMixerMaster = GetComponent<AudioSource>().outputAudioMixerGroup;
    }
    public static void PlaySound(AudioClip audioClip)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        SoundObject soundObject = soundGameObject.AddComponent<SoundObject>();
        audioSource.outputAudioMixerGroup = AudioMixerMaster;
        audioSource.PlayOneShot(audioClip);
    }
}
