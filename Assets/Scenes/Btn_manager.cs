using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_manager : MonoBehaviour
{
    
    public void LoadScene(string scenename){
        SceneManager.LoadScene(scenename);
        Debug.Log("Tombol Berhasil");
    }

    public void TestButton(){
        Debug.Log("Tombol Tentang");
        // SceneManager.LoadScene()
    }
}
