using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BounceEffect : MonoBehaviour
{
   

    [SerializeField]
    private float _durationAll,_duration;
    [SerializeField] private Vector3 _vectroAllSquare;
    [SerializeField] private Vector3 _vectroFlaseAnswer;
    [SerializeField] private Vector3 _vectroTrueAnswer;
    public void Bounce()
    {
       transform.DOShakePosition(_durationAll, strength:_vectroAllSquare, vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
    }

    public void EaseInBounceFalseAnswer()
    {
       transform.DOShakePosition(_duration, strength: _vectroFlaseAnswer, vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
    }
    public void BounceAnswerTrue()
    {
        transform.DOShakePosition(_duration, strength: _vectroTrueAnswer, vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
    }

}
