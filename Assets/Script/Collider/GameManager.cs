using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Portal; // We defin Portal so that we can comparetag


    //Changes the scene acording to the tag.
    public void ChangeScene(){
            if(Portal.CompareTag("Forest"))
            {
                SceneManager.LoadScene("Map-Floor");
            } else if(Portal.CompareTag("River"))
            {
                SceneManager.LoadScene("RiverScene");
            }else if(Portal.CompareTag("Camp"))
            {
                SceneManager.LoadScene("CampSite");
            } else{
                print("Missing Tag");
            }
    }   
}
