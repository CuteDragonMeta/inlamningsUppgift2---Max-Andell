using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnScript : MonoBehaviour
{
    public GameObject treePrefab;
    public int NumberOfTrees;
    public float CollisionCheckRadius;

    void Start()
    {
        CreateObject(treePrefab, NumberOfTrees);
    }
    private void CreateObject(GameObject item, int Amount) {

            for( int i = 0; i < Amount; i++){
            int x = UnityEngine.Random.Range(1,5);

            Vector3 SpawnPoint = new Vector3(UnityEngine.Random.Range(-250,250),0.5f, UnityEngine.Random.Range(-200,300));

                if (FindCollisions(SpawnPoint) < 2){
                    GameObject c = (GameObject)Instantiate(item, SpawnPoint, Quaternion.identity);  
                    c.transform.localScale = new Vector3(5,5,5);
            }
            }
        }
    private int FindCollisions(Vector3 pos){
        Collider[] hits = Physics.OverlapSphere(pos, CollisionCheckRadius);   
        return hits.Length;
    }

}