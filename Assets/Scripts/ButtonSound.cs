using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClick;
    public AudioClip tankPut;
    public AudioClip invPut;
    public AudioClip lizardScurry;
    public AudioClip itemClick;

    private AudioSource audSrc;
    
    void Start()
    {
        audSrc = GetComponent<AudioSource>();  
    }

    public void playButtonClick()
    {
        audSrc.clip = buttonClick;
        audSrc.Play();
    }

    public void playTankPut()
    {
        audSrc.clip = tankPut;
        audSrc.Play();
    }

    public void playInvPut()
    {
        audSrc.clip = invPut;
        audSrc.Play();
    }

    public void playLizardScurry()
    {
        audSrc.clip = lizardScurry;
        audSrc.Play();
    }

    public void playItemClick()
    {
        audSrc.clip = itemClick;
        audSrc.Play();
    }

}
