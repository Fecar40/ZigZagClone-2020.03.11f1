
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public List<Block> Blocks = new List<Block>();
    public List<Diamond> Diamonds = new List<Diamond>();
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private Diamond _diamondPrefab;

    public int NumberOfBlocks;

    private int _blockIndex;
    private int _diamondIndex;


    private void Start()
    {
        for (int i = 0; i < NumberOfBlocks; i++)
        {
            Block block = Instantiate(_blockPrefab);
            Blocks.Add(block);

            Diamond diamond = Instantiate(_diamondPrefab);
            Diamonds.Add(diamond);
            diamond.gameObject.SetActive(false);
        }
    }

    public Block Create(Vector3 position)
    {
        Block block = Blocks[_blockIndex];
        block.transform.position = position;
        _blockIndex++;
        if (_blockIndex >= Blocks.Count)
        {
            _blockIndex = 0;
        }
        return block;
    }

    public void CreateDiamond(Vector3 position)
    {
        int rnd = Random.Range(0, 10);
        if (rnd <= 0.5f)
        {
            Diamond diamond = Diamonds[_diamondIndex];
            diamond.transform.position = position;
            diamond.gameObject.GetComponent<MeshRenderer>().enabled = true;
            diamond.gameObject.SetActive(true);
            _diamondIndex++;
            if(_diamondIndex >= Diamonds.Count)
            {
                _diamondIndex = 0;
            }
        }
    }
}
