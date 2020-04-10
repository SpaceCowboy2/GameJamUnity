using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Palier2 : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> sound = new List<AudioClip>();
    public AudioSource soundBehindYou;
    private AudioClip son;
    public AudioSource soundLeft;
    public AudioSource soundRight;
    private int origins = 0;
    private int volume = 10;
  
    public float timeBetweenTwoSounds = 10.0f;

    //Fonctionne pas
   // public PostProcessProfile PPdrunk;
   // private PPP_Drunk drunk;

    void Start()
    {
        //Fonctionne pas
       // PPdrunk.TryGetSettings(out drunk);
        //drunk.enabled.Override(true);
        //drunk.amplitude.value = 0.3f;


        StartCoroutine(RandomSound(timeBetweenTwoSounds));
        Camera.main.fieldOfView -= 2;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
           
        }
    }

    IEnumerator RandomSound(float timeBetweenTwoSounds)
    {
        while (true)
        {
            if (!soundBehindYou.isPlaying && !soundLeft.isPlaying && !soundRight.isPlaying)
            {
                origins = Random.Range(0, 3);
                volume = Random.Range(10, 51);
                son = sound[Random.Range(0, 6)];
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

            yield return new WaitForSeconds(15);

        }
    }
}