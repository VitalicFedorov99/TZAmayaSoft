using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    [SerializeField]private Text _text;
    [SerializeField]private Image _imageBackground;
    [SerializeField] private Image _imageBootScreen;
    [SerializeField] private float _time; 
    private Tween fadeTween;


    public void FadeIn()
    {
        
        _text.DOFade(1f,_time);
    }

    public void FaidOutBackGround()
    {
        _imageBackground.DOFade(1, _time);
    }

    public void FadeOutText()
    {
        _text.DOFade(0f, _time);
    }
    

    
    public void LaunchingBootScreen()
    {
        _imageBootScreen.color = new Color(255, 255, 255, 0);
        _imageBootScreen.gameObject.SetActive(true);
        _imageBootScreen.DOFade(1f, _time);
        
        StartCoroutine("FirstStage");
       

    }

    IEnumerator FirstStage()
    {
        yield return new WaitForSecondsRealtime(_time);
        _imageBootScreen.DOFade(0, _time);
        
        _imageBackground.color = new Color(0, 0, 0, 0);
        StartCoroutine("SecondStage");
    }

    IEnumerator SecondStage()
    {
        yield return new WaitForSecondsRealtime(5f);
        _imageBackground.color = new Color(0, 0, 0, 0);
        _imageBootScreen.gameObject.SetActive(false);
    }
    

    

   
}
