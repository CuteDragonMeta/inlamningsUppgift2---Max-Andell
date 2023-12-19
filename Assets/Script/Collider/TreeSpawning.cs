using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject Road;

    public GameObject treePrefab;
    public GameObject RockPrefab;
    public GameObject Flower1Prefab;
    public GameObject Flower2Prefab;
    public GameObject Mushroom1Prefab;
    public GameObject Mushroom2Prefab;


    public int NumberOfTrees;
    public int NumberOfFoliage;
    public float CollisionCheckRadius;

    void Start()
    {
        CreateObject(treePrefab, NumberOfTrees);
        CreateObject(RockPrefab, NumberOfFoliage);
        CreateObject(Flower1Prefab, NumberOfFoliage);
        CreateObject(Flower2Prefab, NumberOfFoliage);
        CreateObject(Mushroom1Prefab, NumberOfFoliage);
        CreateObject(Mushroom2Prefab, NumberOfFoliage);
        Destroy(Road, 0);
        }
    private void CreateObject(GameObject item, int Amount) {

            for( int i = 0; i < Amount; i++){
            int x = UnityEngine.Random.Range(3,5);

            Vector3 SpawnPoint = new Vector3(UnityEngine.Random.Range(-250,250),0.5f, UnityEngine.Random.Range(-250,250));

                if (FindCollisions(SpawnPoint) < 2){
                    GameObject c = (GameObject)Instantiate(item, SpawnPoint, Quaternion.identity);  
                    c.transform.localScale = new Vector3(x,x,x);
            }
            }

        }
    private int FindCollisions(Vector3 pos){
        Collider[] hits = Physics.OverlapSphere(pos, CollisionCheckRadius);   
        return hits.Length;
    }

}