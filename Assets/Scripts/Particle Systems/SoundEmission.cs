using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmission : MonoBehaviour
{
    ParticleSystem pS;

    new AudioSource audio;

    int particleAlivecount;

    // Start is called before the first frame update
    void Start()
    {
        pS = gameObject.GetComponent<ParticleSystem>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (pS.particleCount > particleAlivecount)
       {
            audio.Play();
       }

       particleAlivecount = pS.particleCount;
    }
}
