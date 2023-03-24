using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnStone : MonoBehaviour
{
    private int _firstStone;
    private int _secondStone;
    private GameObject _stone;
    private int _row;
    

    public void StoneSpawn()
    {
        if (_stone == null)
        {
            _stone = GameMenejer.instance._stone;
        }
        for (int i = 1; i < 5; i++)
        {
            HorizontallyStone();
            GameMenejer.instance.ObjectSpawn(new Vector3(_firstStone, 0.2f, i), _stone);
            GameMenejer.instance.ObjectSpawn(new Vector3(_firstStone,0.2f,i+8), _stone);
            GameMenejer.instance.ObjectSpawn(new Vector3(_secondStone,0.2f,i), _stone);
            GameMenejer.instance.ObjectSpawn(new Vector3(_secondStone,0.2f,i+8), _stone);
        }
    }

    private void HorizontallyStone()
    {
        var i = 0;
        var e = 8;
        if (_row == 2)
        {
            if (GameMenejer.instance.dataCell[2, 0] != null)
                e = 7;
            if (GameMenejer.instance.dataCell[2, 7] != null)
                i = 1;
        }
        if (_row == 3)
        {
            if (GameMenejer.instance.dataCell[1, 0] != null)
                e = 7;
            if (GameMenejer.instance.dataCell[1, 7] != null)
                i = 1;
        }
        _firstStone = Random.Range(i, e);
        _secondStone = 0;
        int distance = 0;
        while (distance < 2 || distance > 4)
        {
            _secondStone = Random.Range(i, e);
            distance = Mathf.Abs(_firstStone - _secondStone)-1;
        }
            
        if (_row == 3)
        {
            _row = 0;
            return;
        }
        _row++;
    }
}
