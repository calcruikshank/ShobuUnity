using Gameboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    DrawerController drawerController;

    void Awake()
    {
        GameObject gameboardObject = GameObject.FindWithTag("Gameboard");
        drawerController = gameboardObject.GetComponent<DrawerController>();
    }
    public void ResetAllRockems()
    {
        GameboardAnalytics.singleton.SendGameEnd();
        GameboardAnalytics.singleton.SendGameStart();
        foreach (Rock rock in GameManager.singleton.rocksInGame)
        {
            rock.ResetRock();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameboardAnalytics.singleton.SendGameStart();
        drawerController.HideDrawers();
    }

    public void GoToMenu()
    {
        drawerController.ShowDrawers();
        SceneManager.LoadScene(0);
        GameboardAnalytics.singleton.SendGameEnd();
    }
    public void OpenInstruction()
    {
    }
}
