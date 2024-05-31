using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private Button button;

    void Start()
    {
        Debug.Log("GameState: " + GameState.StoryStage.ToString());
        if (GameState.StoryStage == StoryStages.Round1) gameObject.SetActive(true);
        else gameObject.SetActive(false);

        button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return))
        {
            gameObject.SetActive(false);
        }
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
