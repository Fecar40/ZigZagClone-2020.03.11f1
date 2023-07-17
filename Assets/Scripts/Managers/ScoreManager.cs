using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverCurScoreText;
    [SerializeField] private TextMeshProUGUI _gameOverMaxScoreText;
    [SerializeField] private TextMeshProUGUI _mainMenuMaxScoreText;
    [SerializeField] private TextMeshProUGUI _daimontCountText;

    [SerializeField] private List<Color> _colorList = new List<Color>();
    [SerializeField] private Material _blockMat;

    private int _score = -1;
    private int _highscore = 0;
    private int _diamond = 0;
    private int temp = 0;
    private void Start()
    {
        _highscore = Progress.Instance.ShowHighScore();
        _diamond = Progress.Instance.ShowDiamodCount();
        _daimontCountText.text = Progress.Instance.ShowDiamodCount().ToString();
        _gameOverMaxScoreText.text = _highscore.ToString();
        _mainMenuMaxScoreText.text = $"BEST SCORE: {_highscore.ToString()}";
        _blockMat.SetColor("_BaseColor", new Color(0, 0.4980391f,1));
    }
    public void AddScore(int scorePoints)
    {
        _score += scorePoints;
        _scoreText.text = _score.ToString();
        _gameOverCurScoreText.text = _score.ToString();
        temp += scorePoints ;

        if (_score > _highscore)
        {
            _highscore = _score;
            Progress.Instance.SetHighScore(_score);
            _gameOverMaxScoreText.text = Progress.Instance.ShowHighScore().ToString();
        }
        if (temp >= 50)
        {
            temp = 0;
            ChangeColor();  
        }
    }
    public void AddDiamond()
    {
        _diamond++;
        Progress.Instance.SetDiamodCount(_diamond);
    }

    private void ChangeColor()
    {
        int rnd = Random.Range(0, _colorList.Count);
        {
            _blockMat.SetColor("_BaseColor", _colorList[rnd]);
        }
    }
}
