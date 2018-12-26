using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarSeeker.GameScene
{
    public class Block : MonoBehaviour
    {
        private int HP;

        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine("MoveBlock");
            
            HP = Random.Range(1, 10);
            if (Random.Range(0,2) == 0)
            {
                HP = GameManager.Instance.GetStage();
            }
        }

        private IEnumerator MoveBlock()
        {
            while (transform.position.y < 6)
            {
                transform.Translate(Vector2.up * Time.deltaTime);
                yield return null;
            }
            Destroy(gameObject);
            yield return null;
        }

        private void CheckHP()
        {
            if (HP <= 0)
                Destroy(gameObject);
        }
    }

}