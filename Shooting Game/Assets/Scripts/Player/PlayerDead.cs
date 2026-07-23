using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    //reloads the scene to restart the game
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }
}
