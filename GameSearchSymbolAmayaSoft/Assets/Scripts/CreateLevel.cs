using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CreateLevel : MonoBehaviour
{
    [SerializeField] private Task _taskLevel;
    [SerializeField] private CreateSquare _squareLevel;
    [SerializeField] private float _timeVictoryPause;
    [SerializeField] private float _timeRestart;

    [SerializeField] private int _numberLevel = 0;
    [SerializeField] private int _maxlevel;
    [SerializeField] private UpdateParticle _particle;
    [SerializeField]
    private int _easyLine, _easyColumn;
    [SerializeField]
    private int _mediumLine, _mediumColumn;
    [SerializeField]
    private int _hardLine, _hardColumn;

    private int _lineLevel, _columnLevel;

     public UnityEvent _eventVictory;
     public UnityEvent _eventTextFade;
     


   private void ChooseСomplexityLevel()
   {
        switch (_numberLevel)
        {
            case 0:
                _lineLevel = _easyLine;
                _columnLevel = _easyColumn;
                break;

            case 1:
                _lineLevel = _mediumLine;
                _columnLevel = _mediumColumn;
                break;

            case 2:
                _lineLevel = _hardLine;
                _columnLevel = _hardColumn;
                break;
            case 3:
                Victory();
                break;

        }
   }

    public void RestartMission()
    {
        StartCoroutine("WaitAndReStartMission"); 

    }

   

    private  void Victory()
    {
        _squareLevel.ClickSquare(true);
        _eventVictory.Invoke();
    }

    IEnumerator WaitAndReStartMission()
    {
        _numberLevel = 0;
        _taskLevel.ClearTaskCompleted();
       
        _squareLevel.FalseCheckTrueAnswer();
 
        yield return new WaitForSecondsRealtime(_timeRestart);
        StartGame();
    }

    IEnumerator WaitAndNewMissia()
    {
        _particle.StartParticle();
        yield return new WaitForSecondsRealtime(_timeVictoryPause);
        _particle.StopParticle();
        
        if (_numberLevel < _maxlevel)
        {
        
            IncludeFlagCheckTrueAnswer();
            DeactivetElement();
            _numberLevel++;
            ChooseСomplexityLevel();
            CreateTask();
         
            CreateSquare();
        }

    }
    public void CreateNewLevel()
    {
        if (_numberLevel<_maxlevel)
        StartCoroutine("WaitAndNewMissia");
    }
    
    


    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        ChooseСomplexityLevel();
        CreateTask();
        CreatePoolObject();
        CreateSquare();

        _squareLevel.GetComponent<BounceEffect>().Bounce();
        _eventTextFade.Invoke();
    }


    
    private void CreatePoolObject()
    {
        _squareLevel.CreatePool();
    }
    private void CreateTask()
    {
        _squareLevel.SetTrueAnswer(_taskLevel.NewTask());
    }
    
    private void DeactivetElement()
    {
        _squareLevel.DeactivateSquare();
    }

    private void IncludeFlagCheckTrueAnswer()
    {
        _squareLevel.FalseCheckTrueAnswer();
    }
    
    private void CreateSquare()
    {
        
        _squareLevel.SetCountLineAndCountColumn(_lineLevel, _columnLevel);
        _squareLevel.CreateRandPosition();
        _squareLevel.Create();
    }



  
}
