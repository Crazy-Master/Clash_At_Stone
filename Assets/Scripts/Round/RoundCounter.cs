using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    [SerializeField] private GameObject _indicatorRoundFirst;
    [SerializeField] private GameObject _indicatorRoundSecond;
    [SerializeField] private GameObject _IndicatorRoundThird;
    private int _counter;
    private int _roundNumber = 0;
    
    public void Counter(int winner)
    {
        if (_roundNumber == 0)
        {
            if (winner == 1)
            {
                _indicatorRoundFirst.GetComponent<Renderer>().material.color = Color.green;
                _counter++;
            }
            if (winner == 2)
            {
                _indicatorRoundFirst.GetComponent<Renderer>().material.color = Color.red;
                _counter--;
            }
            if (winner == 3)
            {
                _indicatorRoundFirst.GetComponent<Renderer>().material.color = Color.yellow;
            }
            _roundNumber++;
            return;
        }
        if (_roundNumber == 1)
        {
            if (winner == 1)
            {
                _indicatorRoundSecond.GetComponent<Renderer>().material.color = Color.green;
                _counter++;
            }

            if (winner == 2)
            {
                _indicatorRoundSecond.GetComponent<Renderer>().material.color = Color.red;
                _counter--;
            }
            if (winner == 3)
            {
                _indicatorRoundSecond.GetComponent<Renderer>().material.color = Color.yellow;
            }
            _roundNumber++;
            return;
        }
        if (_roundNumber == 2)
        {
            if (winner == 1)
            {
                _IndicatorRoundThird.GetComponent<Renderer>().material.color = Color.green;
                _counter++;
            }

            if (winner == 2)
            {
                _IndicatorRoundThird.GetComponent<Renderer>().material.color = Color.red;
                _counter--;
            }
            if (winner == 3)
            {
                _IndicatorRoundThird.GetComponent<Renderer>().material.color = Color.yellow;
            }
            _roundNumber++;
            GameEnd();
        }
    }

    private void GameEnd()
    {
        if (_counter > 0)
            Debug.Log("---VICTORY---");
        else
            Debug.Log("---GAME OVER---");
    }

    public void ResetColor()
    {
        if (_roundNumber == 3)
        {
            _indicatorRoundFirst.GetComponent<Renderer>().material.color = Color.cyan;
            _indicatorRoundSecond.GetComponent<Renderer>().material.color = Color.cyan;
            _IndicatorRoundThird.GetComponent<Renderer>().material.color = Color.cyan;
            _roundNumber = 0;
        }
    }
}
