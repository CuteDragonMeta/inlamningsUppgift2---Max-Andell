using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandeler : MonoBehaviour
{

    void OnCollisionEnter(){
        SceneManager.LoadScene("Map-Floor");
    }
}
