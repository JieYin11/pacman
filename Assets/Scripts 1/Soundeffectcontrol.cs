using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundeffectcontrol : MonoBehaviour
{
    public AudioClip[] audioClips;

    int AudioOne;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = audioClips[0];
        this.GetComponent<AudioSource>().Play();
    }
    //音效控制
    // Update is called once per frame
    void Update()
    {
        if (AudioOne == 1)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[1])
            {
                this.GetComponent<AudioSource>().clip = audioClips[1];
                this.GetComponent<AudioSource>().Play();

            }

        }
        if (AudioOne == 2)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[2])
            {
                this.GetComponent<AudioSource>().clip = audioClips[2];
                this.GetComponent<AudioSource>().Play();

            }
        }
        if (AudioOne == 3)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[3])
            {
                this.GetComponent<AudioSource>().clip = audioClips[3];
                this.GetComponent<AudioSource>().Play();

            }
        }
        if (this.GetComponent<AudioSource>().clip == audioClips[0] && !this.GetComponent<AudioSource>().isPlaying)
        {

            this.GetComponent<AudioSource>().loop = true;

            AudioOne = 1;

        }
        int Temp = 0;
        for (int i = 0; i < 3; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Monster>().HasDie)
            {
                if (this.GetComponent<AudioSource>().clip != audioClips[3])
                {
                    AudioOne = 2;

                }
                else
                {
                    Temp++;
                }

            }
        }
        if (Temp == 4)
        {
            AudioOne = 1;
        }
        if (PacStudentController.GameType == 1 && AudioOne != 2)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[2])
            {
                AudioOne = 3;
            }

        }
        if (PacStudentController.GameType == 0 && AudioOne == 3)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[1])
            {
                AudioOne = 1;
            }

        }
    }
}
