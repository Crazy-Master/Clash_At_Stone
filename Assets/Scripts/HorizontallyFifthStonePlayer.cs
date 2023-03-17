using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontallyFifthStonePlayer : MonoBehaviour
{
    private int _firstStone;
    private int _secondStone;
    private GameObject _stone;
    

    public void StoneSpawn()
    {
        HorizontallyStone();
        _stone = GameMenejer.instance._stone;
            Instantiate(_stone, new Vector3(_firstStone,0.7f,5), Quaternion.identity);
            Instantiate(_stone, new Vector3(_secondStone,0.7f,5), Quaternion.identity);
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

