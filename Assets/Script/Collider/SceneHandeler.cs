using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandeler : MonoBehaviour
{
    void Update(){
        
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Forest"){
            SceneManager.LoadScene("Map-Floor");
        } if(other.tag == "River"){
            SceneManager.LoadScene("RiverScene");
        }if(other.tag == "Camp"){
            SceneManager.LoadScene("CampSite");
        }
    }

}
