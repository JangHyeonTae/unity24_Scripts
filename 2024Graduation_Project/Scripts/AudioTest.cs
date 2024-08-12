using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(jumpSound, 1f);
    }

   
}
