using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontallyFifthStonePlayer : MonoBehaviour
{
    private int _firstStone;
    private int _secondStone;
    private GameObject _stone;
    

    public bool StoneSpawn()
    {
        HorizontallyStone();
        _stone = GameMenejer.instance._stone;
        GameMenejer.instance.dataCell[5,_firstStone] = Instantiate(_stone, new Vector3(_firstStone,0,5), Quaternion.identity);
        GameMenejer.instance.dataCell[5,_secondStone] = Instantiate(_stone, new Vector3(_secondStone,0,5), Quaternion.identity);
        return true;
    } 
    private void HorizontallyStone() 
    {
        _firstStone = Random.Range(0, 8);
        _secondStone = 0;
        int distance = 0;
        while (distance < 2 || distance > 4)
        {
            _secondStone = Random.Range(0, 8);
            distance = Mathf.Abs(_firstStone - _secondStone)-1;
        }
    }
}

