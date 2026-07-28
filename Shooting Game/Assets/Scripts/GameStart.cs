using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    private InputManager inputManager;

    public GameObject StartScreenUI;
    public GameObject playerPlatform;
    public GameObject spawner;

    void Start()
    {
        inputManager = GameObject.Find("player").GetComponent<InputManager>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //enables onfoot action map, disables startgame action map, removes startscreenui and playerplatform from the scene, enables the spawner
    public void StartGame()
    {
        inputManager.OnFootOnEnable();
        inputManager.StartGameOnDisable();
        StartScreenUI.gameObject.SetActive(false);
        playerPlatform.gameObject.SetActive(false);
        spawner.gameObject.SetActive(true);
    }
}
