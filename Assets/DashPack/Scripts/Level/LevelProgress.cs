using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Image progressImg;

    [SerializeField] private Transform levelEndPos;
    [SerializeField] private Transform playerPos;

    private string saveProgressKey;
    private string saveCoinsKey;

    private int coins = 0;

    private float maxProgress;
    private float curDistance = 0;

    void Start()
    {
        saveProgressKey = "Level" + SceneManager.GetActiveScene().buildIndex + "Progress";
        saveCoinsKey = "Level" + SceneManager.GetActiveScene().buildIndex + "Coins";

        maxProgress = levelEndPos.position.x - playerPos.position.x;
    }

    void Update()
    {
        curDistance = Mathf.InverseLerp(maxProgress, 0, levelEndPos.position.x - playerPos.position.x);
        progressImg.fillAmount = curDistance;
        progressText.text = (curDistance * 100).ToString("0") + "%";
    }

    public void AddCoin()
    {
        coins++;
    }

    public void SaveProgress()
    {
        if (curDistance > PlayerPrefs.GetFloat(saveProgressKey, 0))
        {
            PlayerPrefs.SetFloat(saveProgressKey, curDistance);
            PlayerPrefs.Save();
        }
    }

    public void SaveProgressWithCoins()
    {
        SaveProgress();

        if (coins > PlayerPrefs.GetFloat(saveCoinsKey, 0))
        {
            PlayerPrefs.SetInt(saveCoinsKey, coins);
            PlayerPrefs.Save();
        }
    }
}