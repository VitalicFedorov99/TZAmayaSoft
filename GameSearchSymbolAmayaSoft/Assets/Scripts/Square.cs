using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Square : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _spriteRendererImage;
    
    [SerializeField] private string _name;
    [SerializeField] private bool _TrueAnswer=false;
    [SerializeField] private bool _isVictory = false;

    [SerializeField] private ObsVictory _victory;

    


    public UnityEvent Answer;
    public UnityEvent Victory;

    private void Start()
    {
        
    }
    public void LoadImageSprite(Sprite img)
    {
        
        _spriteRendererImage.sprite = img;
    }

    public void LoadColorCube(Sprite img)
    {

        _spriteRenderer.sprite = img;
    }

    public void LoadNameSquare(string nameSquare)
    {
        _name = nameSquare;
    }

    public void LoadTrueAnswer(bool flag)
    {
        _TrueAnswer = flag;
    }


    public void DestroyObject()
    {
        //Destroy(gameObject);
    }
    public void LoadObsVictory(ObsVictory victory)
    {
        _victory = victory;
    }

    public void LoadIsVictory(bool victory)
    {
        _isVictory = victory;
        Destroy(gameObject,4f);

    }

   

    private void OnMouseDown()
    {
        if (_isVictory == false)
        {
            if (_TrueAnswer == false)
            {
                
                Answer.AddListener(() => _spriteRendererImage.GetComponent<BounceEffect>().EaseInBounceFalseAnswer());
                Answer.Invoke();
                Answer.RemoveAllListeners();
            }
            if (_TrueAnswer == true)
            {
                
                Answer.AddListener(() => _spriteRendererImage.GetComponent<BounceEffect>().BounceAnswerTrue());
                Answer.Invoke();
                Answer.RemoveAllListeners();
                Victory.AddListener(() => _victory.WriteMessageVictory());
                Victory.Invoke();
                Victory.RemoveAllListeners();
                

                

            }
        }
    }

    

}
