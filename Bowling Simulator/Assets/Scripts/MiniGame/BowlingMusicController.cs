using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingMusicController : MonoBehaviour
{
    private StoryStages lastStoryStage;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip screamSound;

    // Update is called once per frame
    void Update()
    {
        StoryStages currentStage = GameState.StoryStage;
        if(currentStage >= StoryStages.Round2 && lastStoryStage != currentStage)
        {
            source.PlayOneShot(screamSound);
            lastStoryStage = currentStage;
        }
    }
}
