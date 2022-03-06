using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    
    private float _pLives = 3;
    private float _pScore = 0;
    [SerializeField] private Text _score;
    [SerializeField] private Text _lives;
    private float _gameWinScore = 160;
    [SerializeField] private Text _gameOverText;
    // Start is called before the first frame update
    void Start() 
    {
        _lives.text = "" + _pLives;
        _score.text = "" + _pScore;
    }

    public void Health() 
    {
        _pLives--;
        _lives.text = "" + _pLives;
        if(_pLives == 0) 
        { 
            GameOver();
        }
    }

    public void Score() 
    { 
        _pScore += 10;
        _score.text = "" + _pScore;
        if (_pScore == _gameWinScore) 
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (_pScore == _gameWinScore)
        {
            _gameOverText.text = "Next Level";
        }
        else 
        {
            _gameOverText.text = "Game Over";
        }
        _gameOverText.gameObject.SetActive(true);
    }


}
