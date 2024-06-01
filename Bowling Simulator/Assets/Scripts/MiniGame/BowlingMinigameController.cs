using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class BowlingMinigameController : MonoBehaviour
{
    private bool didNewGameStarted;

    [SerializeField] private TextMeshProUGUI scoreboardText;
    [SerializeField] private PinResetter pins;
    [SerializeField] private VideoPlayer videoplayer;
    [SerializeField] private VideoClip strike_clip;
    [SerializeField] private VideoClip spare_clip;
    [SerializeField] private VideoClip eyes_clip;

    private bool IsStrike(int roundId)
    {
        return BowlingState.rounds[roundId][0] == 10;
    }

    private short GetStrikeBonus(int roundId)
    {
        short bonus = 0;
        for(int i=roundId+1; i<=Mathf.Min(roundId+2, 9); i++)
        {
            bonus += BowlingState.rounds[i][0];
            bonus += BowlingState.rounds[i][1];
        }
        return bonus;
    }

    private bool IsSpare(int roundId)
    {
        return (BowlingState.rounds[roundId][0] != 10) && BowlingState.rounds[roundId][0] + BowlingState.rounds[roundId][1] == 10;
    }

    private short GetSpareBonus(int roundId)
    {
        short bonus = 0;
        for(int i=roundId+1; i<=Mathf.Min(roundId+1, 9); i++)
        {
            bonus += BowlingState.rounds[i][0];
            bonus += BowlingState.rounds[i][1];
        }
        return bonus;
    }

    private short GetTotalScore()
    {
        short totalScore = 0;
        for(int i=0; i<=BowlingState.currentRound; i++)
        {
            totalScore += BowlingState.rounds[i][0];
            totalScore += BowlingState.rounds[i][1];
            if (IsStrike(i))
            {
                totalScore += GetStrikeBonus(i);
            }
            else if (IsSpare(i))
            {
                totalScore += GetSpareBonus(i);
            }
        }
        return totalScore;
    }

    private void UpdateScoreboard()
    {
        scoreboardText.text = "Runda: " + (BowlingState.currentRound+1).ToString() + ", Rzut: " + (BowlingState.currentRoundHalf+1).ToString() +
            "\n| " + BowlingState.rounds[BowlingState.currentRound][0] + " | " + BowlingState.rounds[BowlingState.currentRound][1] + " |" +
            "\nWynik: " + BowlingState.totalScore;
    }

    void Start()
    {
        videoplayer.enabled = false;
        UpdateScoreboard();
    }

    void Update()
    {
        if(!didNewGameStarted && GameState.StoryStage == StoryStages.Round1)
        {
            didNewGameStarted = true;
            BowlingState.ResetState();
            UpdateScoreboard();
        }
        else if(GameState.StoryStage != StoryStages.Round1)
        {
            didNewGameStarted = false;
        }
    }

    public void OnPinKnockedOver()
    {
        BowlingState.rounds[BowlingState.currentRound][BowlingState.currentRoundHalf]++;
    }

    private IEnumerator PlayFightingSounds()
    {
        yield return new WaitForSeconds(0.15f);
        yield return null;
    }

    public void OnThrowEnd()
    {
        BowlingState.totalScore = GetTotalScore();
        Debug.Log("Totalo wyniko: " + BowlingState.totalScore);

        if (IsStrike(BowlingState.currentRound))
        {
            videoplayer.enabled = true;
            videoplayer.clip = GameState.StoryStage>=StoryStages.Round6 ? eyes_clip : strike_clip;
            videoplayer.Play();
        }

        if (IsSpare(BowlingState.currentRound))
        {
            videoplayer.enabled = true;
            videoplayer.clip = GameState.StoryStage >= StoryStages.Round6 ? eyes_clip : spare_clip;
            videoplayer.Play();
        }

        if (BowlingState.currentRoundHalf == 1 || IsStrike(BowlingState.currentRound))
        {
            BowlingState.currentRound++;
            BowlingState.currentRoundHalf = 0;
            GameState.NextStage();
        }
        else
        {
            BowlingState.currentRoundHalf = 1;
        }

        if (videoplayer.clip)
        {
            StartCoroutine(PlayVideoAndProceed());
        }

        // Execute commands after the video has started and played
        pins.Reset(BowlingState.currentRoundHalf);
        UpdateScoreboard();
    }

    IEnumerator PlayVideoAndProceed()
    {
        while (videoplayer.isPlaying)
        {
            yield return null;
        }

        videoplayer.Stop();
        videoplayer.enabled = false;
        videoplayer.clip = null;
    }

    public short GetCurrentRoundHalf()
    {
        return BowlingState.currentRoundHalf;
    }
}
