using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingState : MonoBehaviour
{
    public static short[][] rounds;
    public static short totalScore;
    public static short currentRound;
    public static short currentRoundHalf;

    static BowlingState()
    {
        rounds = new short[15][];
        for (int i = 0; i < 15; i++)
        {
            rounds[i] = new short[2];
        }
        ResetState();
    }

    public static void ResetState()
    {
        for (int i=0; i<15; i++)
        {
            rounds[i][0] = 0;
            rounds[i][1] = 0;
        }
        currentRound = 0;
        currentRoundHalf = 0;
        totalScore = 0;
    }
}
