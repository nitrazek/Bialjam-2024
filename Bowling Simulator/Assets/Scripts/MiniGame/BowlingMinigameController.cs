using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingMinigameController : MonoBehaviour
{
    private short[][] rounds = new short[10][];
    private short totalScore = 0;
    private short currentRound = 0;
    private short currentRoundHalf = 0;

    private bool IsStrike(int roundId)
    {
        return rounds[roundId][0] == 10;
    }

    private short GetStrikeBonus(int roundId)
    {
        short bonus = 0;
        for(int i=roundId+1; i<=Mathf.Min(roundId+2, 9); i++)
        {
            bonus += rounds[i][0];
            bonus += rounds[i][1];
        }
        return bonus;
    }

    private bool IsSpare(int roundId)
    {
        return rounds[roundId][0] + rounds[roundId][1] == 10;
    }

    private short GetSpareBonus(int roundId)
    {
        short bonus = 0;
        for(int i=roundId+1; i<=Mathf.Min(roundId+1, 9); i++)
        {
            bonus += rounds[i][0];
            bonus += rounds[i][1];
        }
        return bonus;
    }

    private short GetTotalScore()
    {
        short totalScore = 0;
        for(int i=0; i<=currentRound; i++)
        {
            totalScore += rounds[i][0];
            totalScore += rounds[i][1];
            if (IsStrike(i))
            {
                totalScore += GetStrikeBonus(i);
            }
            else if (IsSpare(i))
            {
                totalScore += GetSpareBonus(i);
            }

            Debug.Log("Total score: " + totalScore);
        }
        return totalScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<10; i++)
        {
            rounds[i] = new short[2];
            rounds[i][0] = 0;
            rounds[i][1] = 0;
        }
    }

    public void OnPinKnockedOver()
    {
        rounds[currentRound][currentRoundHalf]++;
    }

    public void OnThrowEnd()
    {
        totalScore = GetTotalScore();

        if(currentRoundHalf == 1 || IsStrike(currentRound))
        {
            currentRound++;
            currentRoundHalf = 0;
        }
        else
        {
            currentRoundHalf = 1;
        }

        //Debug.Log("Total score: " + totalScore + ", Round: " + currentRound);
    }
}
