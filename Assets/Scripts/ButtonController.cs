using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void Retry()
    {
        _animator.SetTrigger("Start");
    }
    public void Share()
    {
        Application.OpenURL("https://viragames.notion.site/Test-Unity-Developer-08e58f2aa53d4dcabd6944d1877a4e28");
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void SetActiveTrue(GameObject gameobject)
    {
        Time.timeScale = 0;
        gameobject.SetActive(true);
    }
    public void SetActiveFalse(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
