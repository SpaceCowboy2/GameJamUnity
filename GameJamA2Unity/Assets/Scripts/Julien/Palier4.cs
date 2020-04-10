using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Palier4 : MonoBehaviour
{
    public List<AudioClip> sound = new List<AudioClip>();
    public AudioSource soundBehindYou;
    private AudioClip son;
    public AudioSource soundLeft;
    public AudioSource soundRight;
    public AudioClip heartBeat;
    public AudioClip heavyBreathing;
    public AudioSource player1;
    public AudioSource player2;
    private int origins = 0;
    private int volume = 10;
    
    public float timeBetweenTwoSounds = 10.0f;

    public PostProcessProfile postProcess;


    private AmbientOcclusion _AmbOcc;
    private Grain _Grain;
   

    void Start()
    {
        StartCoroutine(RandomSound(timeBetweenTwoSounds));
        player1.clip = heartBeat;
        player1.volume = 0.02f;
        player1.Play();
        player2.clip = heavyBreathing;
        player2.volume = 0.04f;
        player2.Play();

        /*********** Post Processing **********/
        postProcess.TryGetSettings(out _AmbOcc);
        postProcess.TryGetSettings(out _Grain);
       

        //set up Ambient Occlusion
        _AmbOcc.enabled.Override(true);

        //set up Grain
        _Grain.enabled.Override(true);

        //set up FOV
        Camera.main.fieldOfView -= 2;
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RandomSound(float timeBetweenTwoSounds)
    {

        while (true)
        {
            if (!soundBehindYou.isPlaying && !soundLeft.isPlaying && !soundRight.isPlaying)
            {
                origins = Random.Range(0, 3);
                volume = Random.Range(10, 51);
                son = sound[Random.Range(0, 11)];
                switch (origins)
                {
                    case 0:
                        soundLeft.clip = son;
                        soundLeft.volume = 0.05f;
                        soundLeft.Play();
                        break;
                    case 1:
                        soundRight.clip = son;
                        soundRight.volume = 0.05f;
                        soundRight.Play();
                        break;
                    case 2:
                        soundBehindYou.clip = son;
                        soundBehindYou.volume = 0.05f;
                        soundBehindYou.Play();
                        break;
                }
            }

            yield return new WaitForSeconds(12);

        }

    }
}
