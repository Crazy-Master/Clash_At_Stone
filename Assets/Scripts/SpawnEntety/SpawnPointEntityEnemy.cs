using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointEntityEnemy : MonoBehaviour
{
    [SerializeField] private RowEntety _rowEntety;

    public void SpawnEntetyEnemy()
    {
        for (int i = 0; i < 8; i++)
        {
            _rowEntety.SpawnEntety(i);
        }

        _rowEntety.ArrayIsFilled();
    }
}
