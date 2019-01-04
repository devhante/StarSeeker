using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarSeeker.GameScene
{
    public class Block : MonoBehaviour
    {
        private int HP;
        private int firstHP;
        Color blockColor;
        
        // Start is called before the first frame update
        private void Start()
        { 
            StartCoroutine("MoveBlock");
            
            HP = Random.Range(1, 10);
            if (Random.Range(0,2) == 0)
            {
                HP += GameManager.Instance.GetStage();
            }
            firstHP = HP;
            blockColor = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(blockColor.r, blockColor.g, blockColor.b, (HP / (10f + GameManager.Instance.GetStage())));
        }

        private IEnumerator MoveBlock()
        {
            while (transform.position.y < 6 && !GameManager.Instance.GetGameOVer())
            {
                transform.Translate(Vector2.up * Time.deltaTime);
                yield return null;
            }
            
            Destroy(gameObject);
            yield return null;
        }

        private void CheckHP()
        {
            HP--;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(blockColor.r, blockColor.g, blockColor.b, (HP / (10f + GameManager.Instance.GetStage())));

            if (HP <= 0)
                Destroy(gameObject);
        }
    }

}