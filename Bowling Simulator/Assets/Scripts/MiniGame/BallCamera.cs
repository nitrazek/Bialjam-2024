using RetroTVFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallCamera : MonoBehaviour
{
    private Vector3 offset;
    private bool isFrozen = false;

    private Transform target;
    [SerializeField] private Transform ball;
    [SerializeField] private Transform head;
    [SerializeField] private RenderTexture sceneInScene;
    [SerializeField] private EventSystem eventSystem;

    private void Start()
    {
        if(GameState.StoryStage == StoryStages.Round5 || GameState.StoryStage >= StoryStages.Round8)
        {
            GetComponent<CRTEffect>().enabled = false;
            GetComponent<AudioListener>().enabled = false;
            eventSystem.enabled = false;
            GetComponent<Camera>().targetTexture = sceneInScene;
        }
    }

    private void Awake()
    {
        target = ball;
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (GameState.StoryStage >= StoryStages.Round9) target = head;
        else target = ball;

        if (!isFrozen) transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
    }

    public void TurnOffTargetTexture()
    {
        GetComponent<Camera>().targetTexture = null;
    }

    public void OnFreeze()
    {
        isFrozen = true;
    }

    public void OnStopFreeze()
    {
        isFrozen = false;
    }
}
