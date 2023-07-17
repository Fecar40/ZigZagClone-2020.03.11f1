using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private BlockManager blockManager;

    private void Start()
    {
        blockManager = FindObjectOfType<BlockManager>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1.5f);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(2f);
        blockManager.CreateBlock();
        GetComponent<MeshRenderer>().enabled = true;
        StopAllCoroutines();
    }
}
