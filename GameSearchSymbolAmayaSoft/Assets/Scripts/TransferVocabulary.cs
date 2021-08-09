using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferVocabulary : MonoBehaviour
{
    [SerializeField]private Task _task;
    [SerializeField]private CreateSquare _createSquare;
    [SerializeField]private Vocabulary _vocabulary;

    private void Start()
    {
        _vocabulary = GetComponent<Vocabulary>();
    }

    public void Transfer()
    {
        ImageOnSquare voc = _vocabulary.ChooseRandVocabulary();
        _task.SetTasks(voc);
        _createSquare.SetImageOnSquare(voc);
    } 
}
