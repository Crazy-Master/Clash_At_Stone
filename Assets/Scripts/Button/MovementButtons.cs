using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButtons : MonoBehaviour
{
    private GameObject[,] _dataCell;
    
    [SerializeField] private MovingEnemy _movingEnemy;

    public void ButtonsMovement()
    {
        var vertical = (int)gameObject.transform.position.z;
        _dataCell = GameMenejer.instance.dataCell; 
        for (int i = 0; i < 8; i++)
        {
            if (_dataCell[vertical, i] != null)
            {
                var objectCell = _dataCell[vertical, i];
                if (objectCell.GetComponent<VarreorEntety>() != null)
                {
                    if (_dataCell[vertical + 1, i] != null)
                    {
                        Destroy(objectCell);
                        _dataCell[vertical, i] = null;
                    }
                    else
                    {
                        objectCell.GetComponent<VarreorEntety>().Muving(1);
                        _dataCell[vertical, i] = null;
                        _dataCell[vertical + 1, i] = objectCell;
                    }
                }
            }
            _movingEnemy.EnemyMoving(vertical);
        }
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, 1);
    }
}
