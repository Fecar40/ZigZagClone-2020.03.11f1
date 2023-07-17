using UnityEngine;
public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _lerpRate;
    private void LateUpdate()
    {
        Vector3 followPosition = new Vector3(_target.position.x, 0, _target.position.z);
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * _lerpRate);
    }
}
