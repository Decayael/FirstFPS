using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void MoveToScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void gameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);

    }
}
