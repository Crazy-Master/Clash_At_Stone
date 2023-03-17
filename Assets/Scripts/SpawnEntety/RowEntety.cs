using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowEntety : MonoBehaviour
{
    private GameObject[] _entetyArrey = new GameObject[8];
    [SerializeField] private int _vertically;
    private int _filledCells;
    public void SpawnEntety(int horizontal)
    {
        if (_entetyArrey[horizontal] == null)
        {
            var pos = new Vector3(horizontal, 0.7f, _vertically);
            GameMenejer.instance.dataCell[_vertically,horizontal] = _entetyArrey[horizontal] = Instantiate(GameMenejer.instance._enemy, pos, Quaternion.identity);
            _entetyArrey[horizontal].GetComponent<VarreorEntety>().strength = horizontal + 1;
            _entetyArrey[horizontal].GetComponent<VarreorEntety>().Strength();
            var stone = _entetyArrey[horizontal];
            stone.transform.SetParent(GameMenejer.instance._rowEntetyPlayr);
            _filledCells++;
            return;
        }
        Debug.Log("клетка занята");
    }

    public int ArrayIsFilled()
    {
        if (_filledCells == 8)
        {
            _filledCells = 0;
            _entetyArrey = new GameObject[8];
            return 1;
        }
        return 0;
    }
    
    
}
