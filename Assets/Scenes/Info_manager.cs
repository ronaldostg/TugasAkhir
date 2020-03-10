using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info_manager : MonoBehaviour
{   
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
    // public void LoadScene(string scenename){
    //     SceneManager.LoadScene(scenename);
    //     // metaData = sch.getMetaData();
    //     // Debug.Log("Menuju info dari :"+metaData);
    // }
}
