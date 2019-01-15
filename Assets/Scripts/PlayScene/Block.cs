using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarSeeker.GameScene
{
    public class Block : MonoBehaviour
    {
        private int HP;         // 블록의 체력 [별에 부딪히면 체력이 줄어듬, 체력이 0이 되면 부서짐]
        Color blockColor;       // 블록의 색깔 [체력이 줄어들수록 연해짐]
        
        // Start is called before the first frame update
        private void Start()    // 체력 랜덤으로 구하기
        { 
            StartCoroutine("MoveBlock");
            
            HP = Random.Range(1, 10);
            if (Random.Range(0,2) == 0)
            {
                HP += GameManager.Instance.GetStage();
            }
            blockColor = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(blockColor.r, blockColor.g, blockColor.b, (HP / (10f + GameManager.Instance.GetStage())));
        }

        private IEnumerator MoveBlock() // 블럭이 서서히 위로 올라감
        {
            while (transform.position.y < 6 && !GameManager.Instance.GetGameOVer())
            {
                transform.Translate(Vector2.up * Time.deltaTime);
                yield return null;
            }
            
            Destroy(gameObject);
            yield return null;
        }

        private void CheckHP()  // 블럭의 체력을 체크하고 0보다 작으면 파괴
        {
            HP--;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(blockColor.r, blockColor.g, blockColor.b, (HP / (10f + GameManager.Instance.GetStage())));

            if (HP <= 0)
                Destroy(gameObject);
        }

        private void CrushBlock()
        {
            Destroy(gameObject);
        }
    }

}