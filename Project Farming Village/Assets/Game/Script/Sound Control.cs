using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audiomixer;

    public void SetVolumeMaster(float volume)
    {
        audiomixer.SetFloat("Master", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        audiomixer.SetFloat("Music", volume);
    }

    public void SetVolumeSoundEffect(float volume)
    {
        audiomixer.SetFloat("Sound Effect", volume);
    }

    public void SetVolumeVoice(float volume)    
    {
        audiomixer.SetFloat("Voice", volume);
    }    
}
