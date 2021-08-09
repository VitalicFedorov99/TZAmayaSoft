using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsVictory : MonoBehaviour
{

    [SerializeField] private CreateLevel _createLevel;
    

    public void WriteMessageVictory()
    {
        
        _createLevel.CreateNewLevel();
    } 

}
