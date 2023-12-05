using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Rendering.Universal;

public class LightingManager : MonoBehaviour
{
    //Referances
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;


    private void OnValidate(){
        if (DirectionalLight !=null)
        return;

        if(RenderSettings.sun!=null){
            DirectionalLight = RenderSettings.sun;
        }else{
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            
        }

    }





}
