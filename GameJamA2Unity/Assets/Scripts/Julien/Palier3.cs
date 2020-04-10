using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Palier3 : MonoBehaviour
{
    public List<AudioClip> sound = new List<AudioClip>();
    public AudioSource soundBehindYou;
    private AudioClip son;
    public AudioSource soundLeft;
    public AudioSource soundRight;
    private int origins = 0;
    private int volume = 10;
    
    public float timeBetweenTwoSounds = 10.0f;

    public PostProcessProfile postProcess;
    

    private Bloom _Bloom;
    private AutoExposure _AutoExposure;
    private ChromaticAberration _Chroma;


    private bool wentOnce = false;

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if(!wentOnce)
        {
            StartCoroutine(RandomSound(timeBetweenTwoSounds));


            /*********** Post Processing **********/
            postProcess.TryGetSettings(out _Bloom);
            postProcess.TryGetSettings(out _AutoExposure);
            postProcess.TryGetSettings(out _Chroma);

            //set up Bloom
            _Bloom.enabled.Override(true);

            //set up Auto Exposure
            _AutoExposure.enabled.Override(true);

            //set up Chromatic Aberration
            _Chroma.enabled.Override(true);

            //set up FOV
            Camera.main.fieldOfView -= 2;
        }
    }

    IEnumerator RandomSound(float timeBetweenTwoSounds)
    {
        wentOnce = false;
        Debug.Log("je suis ici");
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