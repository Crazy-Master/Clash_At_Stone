using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontallyFifthStoneEnemy : MonoBehaviour
{
    private int _firstStone = -1;
    private int _secondStone = -1;
    private bool _canPut;
    public bool HorizontallyStone(int horizontal)
    {
        if (_firstStone != -1 && _secondStone != -1)
        {
            Debug.Log("все стены установлены");
            return false;
        }
        if (_firstStone == -1)
        {
            _firstStone = horizontal;
            return true;
        }
        _secondStone = horizontal;
        int distance = Mathf.Abs(_firstStone - _secondStone);
        if (distance > 2 && distance < 6)
        {
            return true; 
        }
        _secondStone = -1;
        return false;
    }
    
    public void SpawnFiveLine( Vector3 pos)
    {
        _canPut = HorizontallyStone((int)pos.x);
        if (_canPut == true)
        {
            GameMenejer.instance.dataCell[(int)pos.z,(int)pos.x] = Instantiate(GameMenejer.instance._stone, pos, Quaternion.identity);
        }
        else
        {
            Debug.Log("невозможно поставить стену");
        }
    }
    
    public int ArrayIsFilled()
    {
        if (_firstStone != -1 && _secondStone != -1)
        {
            _firstStone = -1; 
            _secondStone = -1;
            return 1;
        }
        return 0;
    }
}
