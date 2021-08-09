using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocabulary : MonoBehaviour
{
    [SerializeField] private ImageOnSquare[] _imageOnSquare;


    public ImageOnSquare ChooseRandVocabulary()
    {
        int rand = Random.Range(0, _imageOnSquare.Length);
        return _imageOnSquare[rand];
    }


}
