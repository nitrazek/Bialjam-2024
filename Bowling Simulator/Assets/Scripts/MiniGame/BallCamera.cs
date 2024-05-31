using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallCamera : MonoBehaviour
{
    private Vector3 offset;
    private bool isFrozen = false;

    [SerializeField] private Transform target;
    [SerializeField] private RenderTexture sceneInScene;
    [SerializeField] private EventSystem eventSystem;

    private void Start()
    {
        if(GameState.StoryStage == StoryStages.Round5)
        {
            GetComponent<Camera>().targetTexture = sceneInScene;
            GetComponent<AudioListener>().enabled = false;
            eventSystem.enabled = false;
        }
    }

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
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
