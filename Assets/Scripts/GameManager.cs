using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _replayButton;
    public PlayerControl player;
    public GameObject panel;

    void Start()
    {
        _replayButton.onClick.AddListener(ReplayGame);
    }

    private void Update()
    {
        if (player.score <= 0)
        {
            panel.SetActive(true);
        }
    }

    void ReplayGame()
    {
        SceneManager.LoadScene("Problem9");
    }
}
