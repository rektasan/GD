using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas levelChooseCanvas;

    void Start()
    {
        OpenLevelChooseMenu(false);
    }

    public void OpenLevelChooseMenu(bool isOpenedNow)
    {
        levelChooseCanvas.enabled = isOpenedNow;
    }
    public void ExitOut()
    {
        Application.Quit();
    }
}
