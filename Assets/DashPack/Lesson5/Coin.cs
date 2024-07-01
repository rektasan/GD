using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void TakeCoin()
    {
        StartCoroutine(CoinPick());
    }

    public IEnumerator CoinPick()
    {
        float timer = 0f;

        Vector3 endPos = transform.position + Vector3.up * 3;

        while (timer < 1f)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * 6);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
