using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGameManager : _MonoBehaviour
{
    public Text _scoreText;

    public void ScoreUp(int score)
    {
        int totalScore = int.Parse(_scoreText.text);
        totalScore += score;
        _scoreText.text = totalScore.ToString();

        PlayerPrefs.SetString("SCORE", _scoreText.text);
        PlayerPrefs.Save();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }

}
