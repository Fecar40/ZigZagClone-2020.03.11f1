using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject _block;
    [SerializeField] private Transform _lastPlatform;
    private Vector3 lastPos;
    private Vector3 NewPos;
    [SerializeField] private ObjectsPool _blocksPool;

    void Start()
    {
        lastPos = _lastPlatform.position;
        for (int i = 0; i < 50; i++)
        {
            CreateBlock();
        }
    }

    public void CreateBlock()
    {
        NewPos = lastPos;
        if (Random.Range(0, 2) == 0)
        {
            NewPos.x += 0.795f;
        }
        else
        {
            NewPos.z += 0.795f;
        }
        _blocksPool.Create(NewPos);
        _blocksPool.CreateDiamond(new Vector3(NewPos.x,NewPos.y+1,NewPos.z));
        lastPos = NewPos;
    }

    private void OnCollisionExit(Collision collision)
    {
        Invoke(nameof(FallPlatform),0.5f);
    }

    private void FallPlatform()
    {
        GetComponent<Rigidbody>().isKinematic= false;
    }
}
