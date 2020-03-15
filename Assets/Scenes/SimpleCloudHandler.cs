using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SimpleCloudHandler : MonoBehaviour, IObjectRecoEventHandler
{

    private CloudRecoBehaviour mCloudRecoBehaviour;
    private bool mIsScanning = false;
    
    private ObjectTracker mImageTracker;
    private GameObject newImageTarget;
    // Start is called before the first frame update
    private static string mTargetName = "";

    private ObjectTracker mObjectTracker;
    public ImageTargetBehaviour imageTargetBehaviour;
    public GameObject gedung_rektorat, entrance_hall, kantin_baru, gedung_9;

    public GameObject gedung_7, kantor_satpam, studio;



   
    void Start()
    {


        // register this event handler at the cloud reco behaviour 
        CloudRecoBehaviour cloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
        

        if (cloudRecoBehaviour)
        {
            cloudRecoBehaviour.RegisterEventHandler(this);
            Debug.Log(cloudRecoBehaviour);
        }

        mCloudRecoBehaviour = cloudRecoBehaviour;
        

        // grabbing all of the game object
        gedung_rektorat = GameObject.Find("gedung_rektorat");
        kantin_baru = GameObject.Find("kantin_baru");
        entrance_hall = GameObject.Find("entrance_hall");
        gedung_9 = GameObject.Find("gedung_9");
        gedung_7 = GameObject.Find("gedung_7");
        kantor_satpam = GameObject.Find("kantor_satpam");
        studio = GameObject.Find("studio");
        
        
    
    }

    public void OnInitialized(TargetFinder targetFinder)
    {
        Debug.Log("Cloud Reco initialized");

        // get a reference to the Image Tracker, remember it
        // mImageTracker = (ObjectTracker)TrackerManager.Instance.GetTracker<ObjectTracker>();

    }

    


    public void OnInitError(TargetFinder.InitState initError)
    {
        Debug.Log ("Cloud Reco init error " + initError.ToString());
    }
    public void OnUpdateError(TargetFinder.UpdateState updateError)
    {
        Debug.Log ("Cloud Reco update error " + updateError.ToString());
    }




    public void OnStateChanged(bool scanning)
    {
        mIsScanning = scanning;
        if (scanning)
        {
             // clear all known trackables
            var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables(false);
            // tracker.TargetFinder.ClearTrackables(false);
        }
    }



    // Here we handle a cloud target recognition event
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {
        

            TargetFinder.CloudRecoSearchResult cloudRecoSearchResult =  (TargetFinder.CloudRecoSearchResult)targetSearchResult;
            // do something with the target name
            
            // mTargetName = cloudRecoSearchResult.TargetName;
            mTargetName = targetSearchResult.TargetName;


            
            
            // stop the target finder (i.e. stop scanning the cloud)
            mCloudRecoBehaviour.CloudRecoEnabled = false;

           

            Debug.Log("Name target :"+mTargetName); 


            //statement untuk menampilkan objek 3d berdasarkan  target name
            if(mTargetName == "gedung_rektorat"){
                gedung_rektorat.SetActive(true);
                kantin_baru.SetActive(false);
                entrance_hall.SetActive(false);
                gedung_9.SetActive(false);
                gedung_7.SetActive(false);
                studio.SetActive(false);
                kantor_satpam.SetActive(false);
            }else if(mTargetName == "kantin_baru"){  
                gedung_rektorat.SetActive(false);
                kantin_baru.SetActive(true);
                entrance_hall.SetActive(false);
                gedung_9.SetActive(false);
                gedung_7.SetActive(false);
                studio.SetActive(false);
                kantor_satpam.SetActive(false);
            }else if(mTargetName == "entrance_hall"){
                gedung_rektorat.SetActive(false);
                kantin_baru.SetActive(false);
                entrance_hall.SetActive(true);
                gedung_9.SetActive(false);
                gedung_7.SetActive(false);
                studio.SetActive(false);
                kantor_satpam.SetActive(false);
            }else if(mTargetName == "gedung_9"){
                gedung_rektorat.SetActive(false);   
                kantin_baru.SetActive(false);
                entrance_hall.SetActive(false);
                gedung_9.SetActive(true);
                gedung_7.SetActive(false);
                studio.SetActive(false);
                kantor_satpam.SetActive(false);
            }else if(mTargetName == "gedung_7"){
                gedung_rektorat.SetActive(false);
                kantin_baru.SetActive(false);
                entrance_hall.SetActive(false);
                gedung_9.SetActive(false);
                gedung_7.SetActive(true);
                studio.SetActive(false);
                kantor_satpam.SetActive(false);
            }else if(mTargetName == "studio"){
                gedung_rektorat.SetActive(false);
                kantin_baru.SetActive(false);
                entrance_hall.SetActive(false);
                gedung_9.SetActive(false);
                gedung_7.SetActive(false);
                studio.SetActive(true);
                kantor_satpam.SetActive(false);
        }
        

        

           


            if (imageTargetBehaviour) {
                // enable the new result with the same ImageTargetBehaviour: 
                ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>(); 
                // (imageTargetBehaviour)tracker.TargetFinder.EnableTracking(targetSearchResult, imageTargetBehaviour.gameObject);
                tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, imageTargetBehaviour.gameObject);

            }

   

       
    }
    
    
    //method yang digunakan untuk mengambil target name dari  
    public static string getTargetName()
    {

        return mTargetName;
        

    }
    



    


    void OnGUI()
    {
        //GUI.Box(new Rect(100, 100, 200, 50), mIsScanning ? "Scanning" : "Not scanning");
        //// // Display metadata of latest detected cloud-target
        //// GUI.Box(new Rect(100, 200, 200, 50), "Metadata: " + mTargetMetadata);
        //// hasil_teks.set 
        // Display target name of latest detected cloud-target
        GUI.Box(new Rect(100, 400, 200, 50), "Target name: " + mTargetName);

        // if(GUI.Button(new Rect(400, 200, 200, 50), "Lihat Info")){
        //     Debug.Log("Menuju halaman info "+mTargetMetadata);
        // }
        // If not scanning, show button
        // so that user can restart cloud scanning
        if (!mIsScanning)
        {
            if (GUI.Button(new Rect(100, 350, 200, 50), "Restart Scanning"))
            {
                // Restart TargetFinder
                mCloudRecoBehaviour.CloudRecoEnabled = true;
                gedung_rektorat.SetActive(false);
                kantin_baru.SetActive(false);
                entrance_hall.SetActive(false);
                gedung_9.SetActive(false);
                gedung_7.SetActive(false);
                studio.SetActive(false);
                kantor_satpam.SetActive(false);
                
            }
        }

        
    }

    










}
