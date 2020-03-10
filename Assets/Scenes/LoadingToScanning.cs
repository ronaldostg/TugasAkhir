using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;

public class LoadingToScanning : MonoBehaviour
{

    public GameObject bar;
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        animateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animateBar(){
        LeanTween.scaleX(bar, 1,time).setOnComplete(loadToScanMarker);
    }

    void loadToScanMarker(){
        SceneManager.LoadScene("scan_marker");
    }
}
