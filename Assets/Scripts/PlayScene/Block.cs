using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("MoveBlock");
    }

    private IEnumerator MoveBlock()
    {
        while (transform.position.y < 6)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
            yield return null;
        }
    }
}
