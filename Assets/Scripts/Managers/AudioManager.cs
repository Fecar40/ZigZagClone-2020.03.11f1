using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOf;
    [SerializeField] private Image _buttonImage;
    private bool mute;

    private void Start()
    {
        mute = Progress.Instance.GetMute();
        if (mute == false)
        {
            AudioListener.volume = 0f;
            _buttonImage.sprite = _soundOf;
        }
        else
        {
            AudioListener.volume = 1f;
            _buttonImage.sprite = _soundOn;
        }
    }
    public void Sound()
    {
        if (mute == false)
        {
            mute = true;
            Progress.Instance.SetMute(mute);
            AudioListener.volume = 1f;
            _buttonImage.sprite = _soundOn;

        }
        else
        {
            mute = false;
            Progress.Instance.SetMute(mute);
            AudioListener.volume = 0f;
            _buttonImage.sprite = _soundOf;

        }
        Progress.Instance.Save();
    }
}
