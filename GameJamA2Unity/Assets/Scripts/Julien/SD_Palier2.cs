using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_Palier2 : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> sound = new List<AudioClip>();
    public AudioSource soundBehindYou;
    private AudioClip son;
    public AudioSource soundLeft;
    public AudioSource soundRight;
    private int origins = 0;
    private int test = 0;
    public float timeBetweenTwoSounds = 10.0f;

    void Start()
    {
        StartCoroutine(RandomSound(timeBetweenTwoSounds));
    }
    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(RandomSound(timeBetweenTwoSounds));
    }

    IEnumerator RandomSound(float timeBetweenTwoSounds)
    {
        while(true)
        {
        Debug.Log(test++);

        if (!soundBehindYou.isPlaying && !soundLeft.isPlaying && !soundRight.isPlaying)
        {
            origins = Random.Range(0, 3);
            son = sound[Random.Range(0, 19)];
            switch (origins)
            {
                case 0:
                    soundLeft.clip = son;
                    soundLeft.Play();
                    break;
                case 1:
                    soundRight.clip = son;
                    soundRight.Play();
                    break;
                case 2:
                    soundBehindYou.clip = son;
                    soundBehindYou.Play();
                    break;
            }
        }

        yield return new WaitForSeconds(10);

        }
    }


}
