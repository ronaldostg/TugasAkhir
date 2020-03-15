using System.Collections;
using System;
using System.Collections.Generic;
using Vuforia;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
// using static SimpleCloudHandler;
//using static SimpleCloudHandler;

public class Info_manager : SimpleCloudHandler
{


   

    // public void setTargetName()
    // {
    //     string target_name = SimpleCloudHandler.getTargetName();
    //     Debug.Log("nama target" + target_name);
    // }

    // public string metaData = "";

    // public ImageTargetBehaviour imageTargetBehaviour;

    // SimpleCloudHandler sch = new SimpleCloudHandler();
    // public void LoadScene(string scenename){
    //     // SceneManager.LoadScene (scenename);
    //     sch.getMetaData()

    //     Debug.Log("Menuju Info ");
    // }

    public void LoadScene(string scenename){
        SceneManager.LoadScene(scenename);
        Debug.Log("Ke halaman Info");
    }





}
