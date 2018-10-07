using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadeCanvas;

    [SerializeField]
    private Animator fadeAnim;

    // Use this for initialization
    void Awake()
    {
        _MakeInstance();
    }

    private void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void FadeIn()
    {
        StartCoroutine(_FadeIn());
    }

    public void FadeOut(String level)
    {
        StartCoroutine(_FadeOut(level));
    }

    IEnumerator _FadeIn()
    {
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        fadeCanvas.SetActive(false);
    }

    IEnumerator _FadeOut(String level)
    {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        Application.LoadLevel(level);
    }
}

