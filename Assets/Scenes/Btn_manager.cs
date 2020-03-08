using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_manager : MonoBehaviour
{
    public void loadToCamera(string scenename){
        SceneManager.LoadScene(scenename);
    }

    
    
    public void keluar(){
        Debug.Log("keluar");
        Application.Quit();
    }

    // public void 

}
