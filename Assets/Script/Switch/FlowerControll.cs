using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.XR.CoreUtils;
using UnityEngine;

public class FlowerControll : MonoBehaviour
{
    //Sound
    private AudioSource source;
    public AudioClip buttonSound;
    //Button Controlls
    private bool on = false;
    private bool buttonHit = false;
    private GameObject button;

    // All flower types
    [SerializeField] GameObject mainFlower;
    public GameObject Flower1;
    public GameObject Flower2;
    public GameObject Flower3;
    


    // Button can be hit again timer
    private float buttonHitTimeOut = 0.5f;
    private float buttonHitAgain;

    private void Start(){
        source = gameObject.AddComponent<AudioSource>();
        // Get button and Position
        mainFlower = transform.GetChild(0).gameObject;
        print(button);
    }

     void Update(){
        if(buttonHit == true){
            //Playsound
            source.PlayOneShot(buttonSound);
            buttonHit = false;

            //if on is true make false, if on is false mae on ture
            on = !on;
            // if on = true, tranform main flower 
            if(on){
                if(mainFlower == Flower1.gameObject){
                    mainFlower = Flower2.gameObject;
                }else if(mainFlower == Flower2.gameObject){
                    mainFlower = Flower3.gameObject;
                }else{
                    mainFlower = Flower1;
                }
            }
        }
     }

     private void OnTriggerStay(Collider other){
        if(other.CompareTag("PlayerHand") && buttonHitAgain < Time.time){
            buttonHitAgain = Time.time + buttonHitTimeOut;
            buttonHit = true;    
        }
     }


}
