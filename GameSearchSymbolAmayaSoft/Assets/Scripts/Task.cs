using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Task : MonoBehaviour
{
    [SerializeField]private List<string> _taskCompleted;
    [SerializeField]private string _trueAnswer;
    [SerializeField]private ImageOnSquare _tasks;

    [SerializeField]private UpdateUI _ui;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }



    public string NewTask()
    {
        
       int randTask=Random.Range(0, _tasks._name.Length);
       bool checkTask = false; 
       for (int i = 0; i < _taskCompleted.Count; i++)
       {
            if (_tasks._name[randTask] == _taskCompleted[i])
            {
                checkTask = true;
                break;
            }
       }
        if (checkTask == true)
        {
            NewTask();
        }
        else
        {
            _trueAnswer = _tasks._name[randTask];
        }
        _taskCompleted.Add(_trueAnswer);

        _ui.LoadTextUI(_trueAnswer);
        return _trueAnswer;
        
    }
    
   
    
    public void SetTasks(ImageOnSquare voc)
    {
        _tasks = voc;
    }


    public void WriteTaskCompleted()
    {
        _taskCompleted.Add(_trueAnswer);
    }

    public void ClearTaskCompleted()
    {
        _taskCompleted.Clear();
    }

    
}
