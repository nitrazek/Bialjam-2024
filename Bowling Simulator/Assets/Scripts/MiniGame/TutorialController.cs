using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private Button button;

    void Start()
    {
        gameObject.SetActive(true);
        button.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
