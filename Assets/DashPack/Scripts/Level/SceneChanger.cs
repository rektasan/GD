using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int CurSceneInd => SceneManager.GetActiveScene().buildIndex;

    public void LoadScene(int sceneInd)
    {
        SceneManager.LoadScene(sceneInd);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}