using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Opening Scene");
        Destroy(GameObject.Find("Game Status"));

    }
}
