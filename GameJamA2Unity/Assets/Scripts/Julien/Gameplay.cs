using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Rendering.PostProcessing;

public class Gameplay : MonoBehaviour
{
    public Image screen;
    public float time;

    public Palier1 palier1;
    public Palier2 palier2;
    public Palier3 palier3;
    public Palier4 palier4;
    public Palier5 palier5;

    public int numberOfShakes = 5;
    public Animator animShake;
    private bool canShake = false;
    public bool Doors;
    public bool calledOnce = true;
    public Image DemenceBar;
    public Animator DoorAnimator;
    private float demence = 0.0f;
    public int etage = -8;

    private bool isOnLevel = false;
    private bool isFailing = false;
    private bool hasWonLevel = false;
    private bool canCountdown = false;
    private bool defeated = true;
    private bool reset = false;

    public List<GameObject> lights = new List<GameObject>();
    private int listLength = 5;
    private int _switch = 5;
    public Light _light;
    private Color32 red;

    public AudioClip monteeAscenceurAvecPortes;
    public AudioClip descenteChute;
    public AudioClip arriveeAscenceur;
    public AudioClip fermeturePorte;
    public AudioClip ouverturePorte;
    public AudioSource ascenceur;
    public AudioClip lampe;

    public AudioSource demon;
    public AudioClip demonspelling1;
    public AudioClip demonspelling2;
    public AudioClip demonspelling3;
    public AudioClip demonspelling4;
    public AudioClip demonspelling5;
    public AudioClip demonspelling6;
    public AudioClip demonspelling7;

    private LensDistortion _LensDis;
    private ColorGrading _ColorGrading;
    private AmbientOcclusion _AmbOcc;
    private Grain _Grain;
    private Bloom _Bloom;
    private AutoExposure _AutoExposure;
    private ChromaticAberration _Chroma;
    public PostProcessProfile PPdrunk;
    private PPP_Drunk drunk;
    public PostProcessProfile postProcess;

    // Start is called before the first frame update
    void Start()
    {

        postProcess.TryGetSettings(out _LensDis);
        postProcess.TryGetSettings(out _ColorGrading);
        postProcess.TryGetSettings(out _AmbOcc);
        postProcess.TryGetSettings(out _Grain);
        postProcess.TryGetSettings(out _Bloom);
        postProcess.TryGetSettings(out _AutoExposure);
        postProcess.TryGetSettings(out _Chroma);
        PPdrunk.TryGetSettings(out drunk);


        _ColorGrading.enabled.Override(false);
        _LensDis.enabled.Override(false);
        _AmbOcc.enabled.Override(false);
        _Grain.enabled.Override(false);
        _Bloom.enabled.Override(false);
        _AutoExposure.enabled.Override(false);
        _Chroma.enabled.Override(false);
        drunk.enabled.Override(false);

        StartCoroutine(WaitForShaking());
        FadeFromBlack();
        red = new Color32(130, 18, 18, 255);
    }

    // Update is called once per frame
    void Update()
    {
        DemenceBar.fillAmount = demence / 100;
        if(demence > 0 && demence < 10) // 0
        {
            
        }
        if (demence >= 10 && demence < 30) // 1
        {
            palier1.enabled = true;
        }
        if (demence >= 30 && demence < 50) // 2
        {
            palier2.enabled = true;
        }
        if (demence >= 50 && demence <= 70) // 3
        {
            palier3.enabled = true;
        }
        if (demence >= 70 && demence < 90) // 4
        {
            palier4.enabled = true;
        }
        if (demence >= 90 && demence < 100) // 5
        {
            palier5.enabled = true;
        }
        if (demence >= 100 )
        {
            if(defeated)
            Defeat();
        }

        if (isOnLevel)
        {
            demence += 0.1f * Time.deltaTime;
            Debug.Log(demence);
        }

        if(isFailing)
        {
            demence += 0.3f * Time.deltaTime;
        }

        if (!calledOnce)
        {
            calledOnce = true;
            StartCoroutine(Shaking());
        }


        if(animShake.GetBool("ShakeAgain") == true && animShake.GetBool("FinishedShaking") == true)
        {
            StartCoroutine(Shaking());
        }
        
        if (canCountdown)
        {
           
            if (listLength > 0 && listLength == _switch && !reset)
            {
                
                switch (etage)
                {
                    case -7:
                        time = 12.0f;
                        demon.clip = demonspelling1;
                        break;
                    case -6:
                        time = 11.0f;
                        demon.clip = demonspelling2;
                        break;
                    case -5:
                        time = 10.0f;
                        demon.clip = demonspelling3;
                        break;
                    case -4:
                        time = 9.0f;
                        demon.clip = demonspelling4;
                        break;
                    case -3:
                        time = 8.0f;
                        demon.clip = demonspelling5;
                        break;
                    case -2:
                        time = 7.0f;
                        demon.clip = demonspelling6;
                        break;
                    case -1:
                        time = 6.0f;
                        demon.clip = demonspelling7;
                        break;

                }
                
                StartCoroutine(TurnOffLights(time));
                StartCoroutine(Demons(time));
            }


        }

        if (Input.GetKeyDown(KeyCode.A))
            hasWonLevel = true;

        if (hasWonLevel)
        {
            StartCoroutine(LevelWon());
        }

    }


    IEnumerator Shaking()
    {
        ascenceur.clip = descenteChute;
        ascenceur.volume = 0.5f;
        ascenceur.Play();
        for (int i = 0; i < 30; i++)
       {
            animShake.SetTrigger("CanShake");
            animShake.Play("ShakeFreeFall");
            yield return new WaitForSeconds(0.16f);            
       }
        animShake.SetBool("ShakeAgain",false); 
        animShake.SetBool("FinishedShaking", true);
        //yield return new WaitForSeconds(3.5f);
        //DoorAnimator.SetBool("CanCloseDoors", false);
        StartCoroutine(DebutLevel());
    }


    IEnumerator WaitForShaking()
    {
        yield return new WaitForSeconds(12.0f);
        calledOnce = false;
        ascenceur.clip = fermeturePorte;
        ascenceur.volume = 0.5f;
        ascenceur.Play();
        DoorAnimator.SetBool("CanCloseDoors", true);
    }

    IEnumerator TurnOffLights(float time)
    {
        if (reset)
        {
            
        }
        
        lights[listLength - 1].gameObject.SetActive(false);
        listLength--;
        yield return new WaitForSeconds(time);

        _switch--;

        if (listLength == 1)
        {
            isFailing = true;
            _light.color = red;
            reset = true;
        }
    }

    IEnumerator TurnOnLights()
    {
        lights[0].gameObject.SetActive(true);
        lights[1].gameObject.SetActive(true);
        lights[2].gameObject.SetActive(true);
        lights[3].gameObject.SetActive(true);
        lights[4].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
            
    }

    private void Defeat()
    {
        defeated = false;
        DoorAnimator.SetBool("CanCloseDoors", true);
        ascenceur.clip = descenteChute;
        ascenceur.volume = 0.5f;
        ascenceur.Play();
        animShake.SetBool("ShakeAgain", true);
        FadeToBlack();
    }

    void FadeToBlack()
    {
        screen.color = Color.black;
        screen.canvasRenderer.SetAlpha(0.0f);
        screen.CrossFadeAlpha(1.0f, 5, false);
    }

    void FadeFromBlack()
    {
        screen.color = Color.black;
        screen.canvasRenderer.SetAlpha(1.0f);
        screen.CrossFadeAlpha(0.0f, 5, false);
    }

    void FadeToWhite()
    {
        screen.color = Color.white;
        screen.canvasRenderer.SetAlpha(0.0f);
        screen.CrossFadeAlpha(1.0f, 5, false);
    }

    IEnumerator DebutLevel()
    {
        etage++;
        
        //On ouvre les portes
        if(etage != -7)
        {
            ascenceur.clip = ouverturePorte;
            ascenceur.volume = 0.5f;
            ascenceur.Play();
        }
        yield return new WaitForSeconds(2.0f);
        DoorAnimator.SetBool("CanCloseDoors", false);
        yield return new WaitForSeconds(2.0f);
        isOnLevel = true;
        canCountdown = true;


        //yield return new WaitForSeconds(12.0f);

    }


    IEnumerator LevelWon()
    {
        canCountdown = false;
        hasWonLevel = false;
        //On monte au niveau suivant
        ascenceur.clip = fermeturePorte;
        ascenceur.volume = 0.5f;
        ascenceur.Play();
        DoorAnimator.SetBool("CanCloseDoors", true);
        isOnLevel = false;
        isFailing = false;
        ascenceur.clip = monteeAscenceurAvecPortes;
        ascenceur.volume = 0.5f;
        ascenceur.Play();
        
        StartCoroutine(TurnOnLights());
        yield return new WaitForSeconds(15.5f);
        ascenceur.clip = arriveeAscenceur;
        ascenceur.volume = 0.30f;
        ascenceur.Play();
        yield return new WaitForSeconds(1.0f);
        DoorAnimator.SetBool("CanCloseDoors", false);
        StartCoroutine(DebutLevel());
    }

    IEnumerator Demons(float time)
    {
            demon.volume = 0.7f;
            demon.Play();
        yield return new WaitForSeconds(time + 1.5f);
    }
}
