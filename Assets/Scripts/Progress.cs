using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    private int _maxPoints;
    private int _diamondCount;
    private bool _mute = false;
    private bool _TestModeOn = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    public void SetHighScore(int value)
    {
        _maxPoints = value;
    }
    public int ShowHighScore()
    {
        return _maxPoints;
    }
    public void SetDiamodCount(int value)
    {
        _diamondCount = value;
    }
    public int ShowDiamodCount()
    {
        return _diamondCount;
    }
    public void SetMute(bool value)
    {
        _mute = value;
    }
    public bool GetMute()
    {
        return _mute;
    }
    public void SetTestMode(bool value)
    {
        _TestModeOn = value;
    }

    public bool GetTestMode()
    {
        return _TestModeOn;
    }

    [ContextMenu("DeliteFile")]
    public void DeliteFile()
    {
        SaveSystem.DeliteFile();
    }

    //Save
    public void Save()
    {
        SaveSystem.Save(this);
    }

    //Load
    public void Load()
    {
        ProgressDate progressDate = SaveSystem.Load();
        if (progressDate != null)
        {
            _maxPoints = progressDate._maxPoints;
            _diamondCount = progressDate._diamondCount;
            _mute = progressDate._mute;
            _TestModeOn = progressDate._testMode;

        }
        else
        {
            _maxPoints = 0;
            _diamondCount = 0;
            _mute = false;
            _TestModeOn = false;
        }

    }
}
