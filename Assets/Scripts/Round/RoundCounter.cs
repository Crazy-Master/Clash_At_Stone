using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    [SerializeField] private GameObject _indicatorRoundFirst;
    [SerializeField] private GameObject _indicatorRoundSecond;
    [SerializeField] private GameObject _IndicatorRoundThird;
    private int _counter;
    private int _roundNumber = 0;
    
    [SerializeField] private AudioClip collectedClipVictory;
    [SerializeField] private AudioClip collectedClipGameOver;
    
    public void Counter(int winner)
    {
        if (_roundNumber == 0)
        {
            if (winner == 1)
            {
                _indicatorRoundFirst.GetComponent<Image>().color = Color.green;
                _counter++;
            }
            if (winner == 2)
            {
                _indicatorRoundFirst.GetComponent<Image>().color = Color.red;
                _counter--;
            }
            if (winner == 3)
            {
                _indicatorRoundFirst.GetComponent<Image>().color = Color.yellow;
            }
            _roundNumber++;
            //Invoke(nameof(DestroyObject), 2f);
            GameMenejer.instance.DestroyObject();
            return;
        }
        if (_roundNumber == 1)
        {
            if (winner == 1)
            {
                _indicatorRoundSecond.GetComponent<Image>().color = Color.green;
                _counter++;
            }

            if (winner == 2)
            {
                _indicatorRoundSecond.GetComponent<Image>().color = Color.red;
                _counter--;
            }
            if (winner == 3)
            {
                _indicatorRoundSecond.GetComponent<Image>().color = Color.yellow;
            }
            _roundNumber++;
            //Invoke(nameof(DestroyObject), 2f);
            GameMenejer.instance.DestroyObject();
            return;
        }
        if (_roundNumber == 2)
        {
            if (winner == 1)
            {
                _IndicatorRoundThird.GetComponent<Image>().color = Color.green;
                _counter++;
            }

            if (winner == 2)
            {
                _IndicatorRoundThird.GetComponent<Image>().color = Color.red;
                _counter--;
            }
            if (winner == 3)
            {
                _IndicatorRoundThird.GetComponent<Image>().color = Color.yellow;
            }
            _roundNumber++;
            GameEnd();
        }
    }

    private void GameEnd()
    {
        if (_counter > 0)
        {
            GameMenejer.instance.victory.SetActive(true);  
            GameMenejer.instance.PlaySound(collectedClipVictory);
        }
        else
        {
            GameMenejer.instance.gameOver.SetActive(true);
            GameMenejer.instance.PlaySound(collectedClipGameOver);
        }
        GameMenejer.instance._nextButton.SetActive(true);
    }

    public void ResetColor()
    {
        if (_roundNumber == 3)
        {
            _indicatorRoundFirst.GetComponent<Image>().color = Color.cyan;
            _indicatorRoundSecond.GetComponent<Image>().color = Color.cyan;
            _IndicatorRoundThird.GetComponent<Image>().color = Color.cyan;
            _roundNumber = 0;
        }
    }
    
    // private void DestroyObject()
    // {
    //     GameMenejer.instance.DestroyObject();
    // }
}
