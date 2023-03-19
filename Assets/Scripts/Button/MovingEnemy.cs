using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    //private int _horizontal;
    private GameObject[,] _dataCell;

    public void EnemyMoving(int vertical)
    {
        var z = Mathf.Abs(vertical - 13);
        _dataCell = GameMenejer.instance.dataCell;

            for (int i = 0; i < 8; i++)
            {
                if (_dataCell[z, i] != null)
                {
                    var objectCell = _dataCell[z, i];
                    if (objectCell.GetComponent<VarreorEntety>() != null)
                    {
                        if (_dataCell[z - 1, i] != null)
                        {
                            Destroy(objectCell);
                            _dataCell[z, i] = null;
                        }
                        else
                        {
                            objectCell.GetComponent<VarreorEntety>().Muving(-1);
                            _dataCell[z, i] = null;
                            _dataCell[z - 1, i] = objectCell;
                        }
                    }
                }
            }
    }
    }
