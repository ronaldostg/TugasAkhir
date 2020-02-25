using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleCloudHandler : MonoBehaviour, IObjectRecoEventHandler
{

    private CloudRecoBehaviour mCloudRecoBehaviour;
    private bool mIsScanning = false;
    
    private ObjectTracker mImageTracker;
    private GameObject newImageTarget;
    // Start is called before the first frame update
    private string mTargetMetadata = "";
    private string mTargetName = "";

    private ObjectTracker mObjectTracker;
    public ImageTargetBehaviour imageTargetBehaviour;
    public GameObject gedung_rektorat, entrance_hall, kantin_baru;
    // public Text hasil_teks;



    // public string nama_gedung;



    // public GameObject gedung_rektorat, entrance_hall;
    //public ImageTargetBehaviour ImageTargetTemplate;




    public SimpleCloudHandler(){

    }
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
    }

    public void OnInitialized(TargetFinder targetFinder)
    {
        Debug.Log("Cloud Reco initialized");

        // get a reference to the Image Tracker, remember it
        mImageTracker = (ObjectTracker)TrackerManager.Instance.GetTracker<ObjectTracker>();

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
            ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables(false);
            //var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            //tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables(false);
        }
    }




    //<param name = "targetSearchResult" ></ param >
    // Here we handle a cloud target recognition event
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {
        
        try{
            TargetFinder.CloudRecoSearchResult cloudRecoSearchResult = (TargetFinder.CloudRecoSearchResult)targetSearchResult;
            // do something with the target metadata
            //mTargetMetadata = cloudRecoSearchResult.MetaData;
            // stop the target finder (i.e. stop scanning the cloud)
            //mCloudRecoBehaviour.CloudRecoEnabled = false;
            //GameObject newImageTarget = Instantiate(ImageTargetTemplate.gameObject) as GameObject;

            GameObject newImageTarget = Instantiate(imageTargetBehaviour.gameObject) as GameObject;

            GameObject augmentation = null;

            if (augmentation != null)
                augmentation.transform.parent = newImageTarget.transform;
            
        
            imageTargetBehaviour =(ImageTargetBehaviour)mImageTracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, newImageTarget);
            // do something with the target metadata
            mTargetMetadata = cloudRecoSearchResult.MetaData;
            mTargetName = cloudRecoSearchResult.TargetName;
            // stop the target finder (i.e. stop scanning the cloud)
            mCloudRecoBehaviour.CloudRecoEnabled = false;
            // getMetaData();

            string model_name = mTargetMetadata;

            // // while(mIsScanning==)
            switch (model_name)
            {
            case "entrance_hall":
                Destroy(imageTargetBehaviour.gameObject.transform.Find("gedung_rektorat"));
                Destroy(imageTargetBehaviour.gameObject.transform.Find("kantin_baru").gameObject);
                break;
            case "gedung_rektorat":

                   Destroy(imageTargetBehaviour.gameObject.transform.Find("entrance_hall").gameObject);
                   Destroy(imageTargetBehaviour.gameObject.transform.Find("kantin_baru").gameObject);
            
                break;

                case "kantin_baru" :
                    Destroy(imageTargetBehaviour.gameObject.transform.Find("gedung_rektorat"));
                    Destroy(imageTargetBehaviour.gameObject.transform.Find("entrance_hall").gameObject);
                    break;
            }

            // Debug.Log(model_name);

            

            
            // if (model_name == "entrance_hall")
            // {
            //     Destroy(imageTargetBehaviour.gameObject.transform.Find("gedung_rektorat").gameObject);
            // }
            // else if (model_name == "gedung_rektorat")
            // {
            //     Destroy(imageTargetBehaviour.gameObject.transform.Find("entrance_hall").gameObject);
            // }
            
                
            


            if (!mIsScanning)
            {
                // stop the target finder
                mCloudRecoBehaviour.CloudRecoEnabled = true;
            }

        }catch(Exception e){
            Debug.LogWarning("Letak error terdapat di : "+ e,this);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 200, 50), mIsScanning ? "Scanning" : "Not scanning");
        // Display metadata of latest detected cloud-target
        GUI.Box(new Rect(100, 200, 200, 50), "Metadata: " + mTargetMetadata);
        // hasil_teks.set

        GUI.Box(new Rect(100, 300, 200, 50), "Target name: " + mTargetName);

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
            }
        }
    }

    // public void LoadInfo(string metadata){
    //     // SceneManager.LoadScene(scene)
    //     TargetFinder.TargetSearchResult targetSearchResult;
    //     TargetFinder.CloudRecoSearchResult cloudRecoSearchResult = (TargetFinder.CloudRecoSearchResult)targetSearchResult;
    //     metadata = cloudRecoSearchResult.MetaData;
    //     Debug.Log("Menuju halaman info "+metadata);
    // }

    // public string getMetaData(){
    //     return this.mTargetMetadata;
    // }
    
}
