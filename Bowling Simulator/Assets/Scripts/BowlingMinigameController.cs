using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingMinigameController : MonoBehaviour
{
    private short[][] rounds = new short[10][];

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
