using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointEntityEnemy : MonoBehaviour
{
    [SerializeField] private RowEntety _rowEntety;

    public bool SpawnEntetyEnemy()
    {
        for (int i = 0; i < 8; i++)
        {
            _rowEntety.SpawnEntety(i, GameMenejer.instance._enemy);
        }
        _rowEntety.ArrayIsFilled();
        return true;
    }
}
