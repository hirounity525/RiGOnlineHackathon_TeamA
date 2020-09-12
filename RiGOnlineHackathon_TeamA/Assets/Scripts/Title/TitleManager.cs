using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float startDuration;

    private SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    private void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0.99f);
        fadeImage.DOFade(0.0f, startDuration).SetEase(Ease.OutCubic);
    }

    private void Update()
    {
        if(fadeImage.color.a >= 1.0f)
        {
            sceneLoader.Load("Main");
        }
    }

    public void FadeOutImage()
    {
        fadeImage.DOFade(1.0f, startDuration).SetEase(Ease.OutCubic);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
