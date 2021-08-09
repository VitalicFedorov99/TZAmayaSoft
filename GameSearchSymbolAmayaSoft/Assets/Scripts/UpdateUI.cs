using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateUI : MonoBehaviour
{

    [SerializeField]private Text _text;
    [SerializeField]private GameObject _button;
    
   
    public void LoadTextUI(string answer)
    {
        _text.text = "Find " + answer;
    }

    public void IncludeRestart()
    {
        _button.SetActive(true);
    }

    public void OffRestart()
    {
        _button.SetActive(false);
    }


    
}
