using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudio : MonoBehaviour
{
    public AudioSource Test;
    public AudioClip Click;

    public void ClickSound()
    {
        Test.PlayOneShot(Click);
    }

}
