using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnStone : MonoBehaviour
{
    private int[] _horizontallyStone = new int [2] ;
    [SerializeField] private GameObject _stone;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) StoneSpawn(_stone);
    }

    public void StoneSpawn(GameObject stone)
    {
        for (int i = 1; i < 6; i++)
        {
            HorizontallyStone();
            Instantiate(stone, new Vector3(_horizontallyStone[0],0,i), Quaternion.identity);
            Instantiate(stone, new Vector3(_horizontallyStone[0],0,i+7), Quaternion.identity);
            Instantiate(stone, new Vector3(_horizontallyStone[1],0,i), Quaternion.identity);
            Instantiate(stone, new Vector3(_horizontallyStone[1],0,i+7), Quaternion.identity);
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
            distance = firstStone - secondStone;
            if (distance < 0)
            {
                distance = distance * -1;
            }
        }

        _horizontallyStone[0] = firstStone;
        _horizontallyStone[1] = secondStone;
    }
}
