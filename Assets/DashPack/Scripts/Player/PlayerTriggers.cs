using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private SceneChanger sceneChanger;

    [SerializeField] private LevelProgress levelProgress;

    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private ParticleSystem trailParticles;

    [SerializeField] private Transform portalPos;

    [SerializeField] private GameObject playerModel;

    private Rigidbody2D rgb;
    private MoveCube moveCube;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        moveCube = GetComponent<MoveCube>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            if (moveCube.enabled)
            {
                StartCoroutine(DeathTimer());
            }
        }
        else if (collision.tag == "WinZone")
        {
            if (moveCube.enabled)
            {
                StartCoroutine(WinTimer());
            }
        }
        else if (collision.tag == "Coin")
        {
            levelProgress.AddCoin();
            collision.GetComponent<Coin>().TakeCoin();
            collision.enabled = false;
        }
    }

    IEnumerator DeathTimer()
    {
        moveCube.enabled = false;
        rgb.constraints = RigidbodyConstraints2D.FreezeAll;
        playerModel.SetActive(false);

        trailParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        deathParticles.Play();

        levelProgress.SaveProgress();

        while (deathParticles.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        sceneChanger.ReloadScene();
    }

    IEnumerator WinTimer()
    {
        moveCube.enabled = false;
        rgb.constraints = RigidbodyConstraints2D.FreezeAll;
        trailParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        float timer = 0f;

        while (timer < 1f)
        {
            playerModel.transform.Rotate(Vector3.back, 225f * Time.deltaTime);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        levelProgress.SaveProgressWithCoins();

        timer = 0f;

        while (timer < 2f)
        {
            playerModel.transform.position = Vector3.Lerp(playerModel.transform.position, portalPos.position, Time.deltaTime * 2f);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        sceneChanger.LoadScene(0);
    }
}