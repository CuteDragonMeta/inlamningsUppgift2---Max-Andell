using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManegar : MonoBehaviour
{
    [SerializeField]GameObject CurrentRocket;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator rocketSpawn(Collider collision, int time, GameObject Rocket){
        yield return new WaitForSeconds(time);
        Instantiate(Rocket, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void OnTriggerEnter(Collider collision){
        StartCoroutine(rocketSpawn(collision, 5, CurrentRocket));
    }

}
