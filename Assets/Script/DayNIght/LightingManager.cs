using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Rendering.Universal;


[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Referances
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;
    [SerializeField] private int Speed;
    public Material Morning;
    public Material Day;
    public Material SunDown_Up;
    public Material Night;




    private void Update(){
        SkyboxChange();

        if (Preset == null)
            return;

        if(Application.isPlaying){
            TimeOfDay += Time.deltaTime / Speed;
            TimeOfDay %= 24; // camlp between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }else{
            UpdateLighting(TimeOfDay/24f);
        }
    }

    private void SkyboxChange(){
         if(TimeOfDay >= 6f || TimeOfDay < 9f){
            RenderSettings.skybox = Morning;
        }else if(TimeOfDay >= 9f || TimeOfDay < 16f){
            RenderSettings.skybox = Day;
        }else if(TimeOfDay >= 18f || TimeOfDay < 5f){
            RenderSettings.skybox = Night;
        } else{
            RenderSettings.skybox = SunDown_Up;
        } 
    }

// updates the lighting by assinging it its preset and makeing sure that the dircationalLight is rotated correctly
    private void UpdateLighting(float timePercent){
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight!=null){
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) -90f,170,0));
        }
    }

// makes sure that the scene has a direcional light
    private void OnValidate(){
        if (DirectionalLight !=null)
        return;

        if(RenderSettings.sun!=null){
            DirectionalLight = RenderSettings.sun;
        }else{
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights){
                if(light.type == LightType.Directional){
                    DirectionalLight = light;
                    return;
                }
            }
        }

    }





}
