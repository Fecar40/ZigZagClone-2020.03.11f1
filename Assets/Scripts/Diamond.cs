using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fx;
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _fx.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Start");
            gameObject.GetComponent<AudioSource>().Play();
            _scoreManager.AddScore(2);
            _scoreManager.AddDiamond();
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}
