using UnityEngine;
using UnityEngine.UI;

public enum Direrction
{
    X,
    Z
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Toggle _testModeToggle;
    [SerializeField] private Transform point;

    private Direrction _direction;
    private bool _testModeOn = false;

    private void Start()
    {
        _testModeOn = Progress.Instance.GetTestMode();
        _direction = Direrction.Z;
        _testModeToggle.isOn = Progress.Instance.GetTestMode();
    }

    private void Update()
    {
        Move();
        if (transform.position.y < -7)
        {
            _gameManager.GameOver();
        }
    }

    private void Move()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        //Automatically Movement
        if (_testModeOn == true)
        {
            Ray ray = new Ray(point.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 0.8f))
            {
            }
            else
            {
                if (_direction == Direrction.Z)
                {
                    _direction = Direrction.X;
                    transform.rotation = Quaternion.Euler(0, 90, 0);

                }
                else
                {
                    _direction = Direrction.Z;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    public void ChangeDirection()
    {
        if (_testModeOn == false)
        {
            if (_direction == Direrction.Z)
            {
                _direction = Direrction.X;
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                _direction = Direrction.Z;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            _scoreManager.AddScore(1);
        }
    }

    public void AutomaticallyMoveMent(bool value)
    {
        _testModeOn = value;
        Progress.Instance.SetTestMode(value);
        Progress.Instance.Save();
    }
}
