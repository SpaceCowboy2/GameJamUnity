using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Palier1 : MonoBehaviour
{ // Start is called before the first frame update
    
    public PostProcessProfile PPdrunk;
    private PPP_Drunk drunk;

    void Start()
    {
       
        PPdrunk.TryGetSettings(out drunk);
        drunk.enabled.Override(true);
        Camera.main.fieldOfView -= 2;
    }
    // Update is called once per frame
    void Update()
    {

    }


}
