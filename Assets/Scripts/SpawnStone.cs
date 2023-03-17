using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnStone : MonoBehaviour
{
    private int[] _horizontallyStoneArrey = new int [2] ;
    private GameObject _stone;

    private void Update()
    {
       // if (Input.GetMouseButtonDown(1)) StoneSpawn();
    }

    public void StoneSpawn()
    {
        if (_stone == null)
        {
            _stone = GameMenejer.instance._stone;
        }
        
        for (int i = 1; i < 5; i++)
        {
            HorizontallyStone();
            var asd = GameMenejer.instance.dataCell;
           asd[i,_horizontallyStoneArrey[0]] = Instantiate(_stone, new Vector3(_horizontallyStoneArrey[0],0.7f,i), Quaternion.identity);
           asd[i+8,_horizontallyStoneArrey[0]] =  Instantiate(_stone, new Vector3(_horizontallyStoneArrey[0],0.7f,i+8), Quaternion.identity);
           asd[i,_horizontallyStoneArrey[1]] =  Instantiate(_stone, new Vector3(_horizontallyStoneArrey[1],0.7f,i), Quaternion.identity);
           asd[i+8,_horizontallyStoneArrey[1]] =  Instantiate(_stone, new Vector3(_horizontallyStoneArrey[1],0.7f,i+8), Quaternion.identity);
        }
        
    }

    private void HorizontallyStone()
    {
        int  firstStone = Random.Range(0, 8);
        int secondStone = 0;
        int distance = 0;
        while (distance < 2 || distance > 4)
        {
            secondStone = Random.Range(0, 8);
            distance = Mathf.Abs(firstStone - secondStone)-1;
        }

        _horizontallyStoneArrey[0] = firstStone;
        _horizontallyStoneArrey[1] = secondStone;
    }
}
