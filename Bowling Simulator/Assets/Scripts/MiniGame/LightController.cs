using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightController : MonoBehaviour
{
    private float startIntensity = 1;
    private float endIntensity = 4;
    private Color startColor = new Color32(0xFF, 0x00, 0xBF, 0xFF);
    private Color endColor = new Color32(0xFF, 0x00, 0x00, 0x00);
    private StoryStages currentStage;
    private int step = 0;

    [SerializeField] private Light light;

    void Update()
    {
        if(GameState.StoryStage != currentStage)
        {
            currentStage = GameState.StoryStage;
            step++;
            float t = (float)step / 10;
            light.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
            light.color = Color.Lerp(startColor, endColor, t);
        }
    }
}
