using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingMusicController : MonoBehaviour
{
    private StoryStages lastStoryStage;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip screamSound;
    [SerializeField] private AudioClip[] barkSounds;

    private void Start()
    {
            source.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.Hangar;
    }

    // Update is called once per frame
    void Update()
    {
        StoryStages currentStage = GameState.StoryStage;
        if(currentStage >= StoryStages.Round2 && lastStoryStage != currentStage)
        {
            source.PlayOneShot(screamSound);
        }
        if (currentStage == StoryStages.Round3 && lastStoryStage != currentStage)
        {
            source.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.Psychotic;
        }
        if (currentStage >= StoryStages.Round5 && lastStoryStage != currentStage)
        {
            StartCoroutine(PlayRandomBarking());
        }
        lastStoryStage = currentStage;
    }

    private IEnumerator PlayRandomBarking()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, barkSounds.Length);
            AudioClip randomBark = barkSounds[randomIndex];
            
            source.PlayOneShot(randomBark);

            yield return new WaitForSeconds(randomBark.length);
            float randomDelay = Random.Range(1, 5);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
