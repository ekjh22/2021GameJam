using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager.Scene;

public class Intro : MonoBehaviour
{
    [SerializeField] private Image[] imgs = null;
    int count = 0;

    void Start()
    {
        StartCoroutine(FadeIn(count)); // 1
    }

    void Update()
    {
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("WaitOut", 1.5f);
            Invoke("WaitIn", 1.5f);
        }
    }

    void WaitIn()
    {
        StartCoroutine(FadeIn(count));
    }

    void WaitOut()
    {
        StartCoroutine(FadeOut(count - 1));
    }

    IEnumerator FadeIn(int i)
    {
        count++;
        float progress = 0f;
        imgs[i].gameObject.SetActive(true);

        while (progress <= 1f)
        {
            imgs[i].color = new Color(255f, 255f, 255f, progress);
            progress += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut(int i)
    {
        float progress = 1f;

        while (progress >= 0f)
        {
            imgs[i].color = new Color(255f, 255f, 255f, progress);
            progress -= Time.deltaTime;
            yield return null;
        }
        imgs[i].gameObject.SetActive(false);

        if (count > imgs.Length)
            Loader.Load(Scene.Title);
    }
}
