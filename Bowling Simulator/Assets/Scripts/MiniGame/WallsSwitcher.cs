using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject wallsFlesh;

    void Update()
    {
        if (GameState.StoryStage >= StoryStages.Round10)
        {
            walls.SetActive(false);
            wallsFlesh.SetActive(true);
            return;
        }
        walls.SetActive(true);
        wallsFlesh.SetActive(false);
    }
}
