using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager Mine;

    void Start()
    {
        Mine = this;    
    }

    public AudioSource Music, SFX;
    public AudioClip Jump;

    public void Jump_SFX()
    {
        SFX.PlayOneShot(Jump);
    }
}
