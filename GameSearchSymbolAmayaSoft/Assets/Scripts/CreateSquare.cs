using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CreateSquare : MonoBehaviour
{
    [SerializeField]
    private float _xSize, _ySize;

    [SerializeField] private int _countLine;
    [SerializeField] private int _countColumn;
    [SerializeField] private Square _prefab;
    private Square[,] _square;
    [SerializeField] private ImageOnSquare _imageOnSquare;
    [SerializeField] private ColorSquare _colorSquare;
    [SerializeField] private string _trueAnswer;
    [SerializeField] private bool _checkTrueAnswer=false;

    [SerializeField] private int _randPositionTrueAnswer;
    [SerializeField] private ObsVictory _obsVictory;

    [SerializeField] private int poolCount = 9;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private int _countSquare = 0;

     private PoolMono<Square> pool;
    

   
    public void SetImageOnSquare(ImageOnSquare voc)
    {
        _imageOnSquare = voc;
    }

    public void SetTrueAnswer(string trueAnswer)
    {
        _trueAnswer = trueAnswer;
    }

    public void SetCountLineAndCountColumn(int countLine,int countColumn)
    {
        _countLine = countLine;
        _countColumn=countColumn;
    }



    public void CreateRandPosition()
    {
        
        _randPositionTrueAnswer = Random.Range(0, _countColumn * _countLine);
    }
  

    public int SearchElement(string nameElement)
    {
        int number=-1;
        for( int i=0;i < _imageOnSquare._name.Length; i++)
        {
            if (nameElement == _imageOnSquare._name[i])
            {
                number = i;
                break;
            }
        }
        return number;

    }
    
    public void CreatePool()
    {   
        pool = new PoolMono<Square>(_prefab, poolCount, transform);
        pool.autoExpand = autoExpand;
    }
   

    

    public void Create()
    { 
        _xSize = _prefab.transform.localScale.x;
        _ySize = _prefab.transform.localScale.y;
        
        _square = new Square[_countLine, _countColumn];
        Vector3 offset = new Vector3(0, 0, 0); 
        for( int i = 0; i < _countLine; i++)
        {
            for( int j = 0; j < _countColumn; j++)
            {

                var square = _square[i, j] = pool.GetFreeElement();
                if (_countSquare == _randPositionTrueAnswer)
                {
                    OneTrueAnswer(square);
                }
                else
                {
                    RandomSquare(square);
                }

                square.LoadObsVictory(_obsVictory);
                square.transform.SetParent(transform,false);
                square.transform.localPosition = new Vector3(offset.x, offset.y, 0);
                offset.x = offset.x + (_xSize * 2);
                _countSquare++;
            }
            offset.x = 0;
            offset.y = offset.y + (_ySize * 2);
        }
 

    }

    private void OneTrueAnswer(Square square)
    {
        
        if (_checkTrueAnswer == false) {
           
            {
                int id = SearchElement(_trueAnswer);
                int randColor = Random.Range(0, _colorSquare._color.Length);
                 square.LoadImageSprite(_imageOnSquare._sprite[id]);
                square.LoadColorCube(_colorSquare._color[randColor]);
                square.LoadNameSquare(_imageOnSquare._name[id]);
                square.LoadTrueAnswer(true);
               
                _checkTrueAnswer = true;
               
            }
        }
        
    }


   public void DeactivateSquare()
    {
       for(int i = 0; i < _countLine; i++)
        {
            for( int j = 0; j < _countColumn; j++)
            {
                _square[i, j].gameObject.SetActive(false);
            }
        }
        
    }

  

   public void ClickSquare(bool flag)
    {
        for (int i = 0; i < _countLine; i++)
        {
            for (int j = 0; j < _countColumn; j++)
            {
                _square[i, j].LoadIsVictory(flag);
            }
        }

    }

    

    public void FalseCheckTrueAnswer()
    {
        _checkTrueAnswer = false;
        _countSquare = 0;
    }

   private void RandomSquare(Square square)
   {   
        int rand=Random.Range(0, _imageOnSquare._name.Length);  
        int randColor = Random.Range(0, _colorSquare._color.Length);
        square.LoadImageSprite(_imageOnSquare._sprite[rand]);
        square.LoadColorCube(_colorSquare._color[randColor]);
        square.LoadNameSquare(_imageOnSquare._name[rand]);
        square.LoadTrueAnswer(false);
        if (_trueAnswer == _imageOnSquare._name[rand])
        {
            RandomSquare(square);
        }
        
   }

  
   
}
