[System.Serializable]
public class ProgressDate
{
    public int _maxPoints;
    public int _diamondCount;
    public bool _mute = false;
    public bool _testMode = false;

    public ProgressDate(Progress progess)
    {
        _maxPoints = progess.ShowHighScore();
        _diamondCount = progess.ShowDiamodCount();
        _mute= progess.GetMute();
        _testMode = progess.GetTestMode();
    }
}
