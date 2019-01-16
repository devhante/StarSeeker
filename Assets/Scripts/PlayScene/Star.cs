using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarSeeker.GameScene
{
    public class Star : MonoBehaviour
    {
        [SerializeField] private float jumpHeight;      // 얼마나 높이 점프하는지
        [SerializeField] private float skillSpeed;      // 스킬이 사용시 얼마나 빨리 떨어지는지
        [SerializeField] private int demandEnergy;    // 스킬을 사용하는데 필요한 에너지

        private Rigidbody2D rigidbody2D;            // 각종 물리연산
        private bool jumping = false;               // 점프하는지 체크
        private bool usingSkill = false;                    // 스킬 사용중인지 체크
        private int skillEnergy = 0;                    // 에너지가 다차면 스킬 사용가능


        // Start is called before the first frame update
        private void Start()
        {
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.freezeRotation = true;
            StartCoroutine("MoveStar");
            StartCoroutine("CrushBlock");
        }

        private IEnumerator MoveStar()  // 터치하는 방향으로 이동
        {
            while (gameObject.activeSelf)
            {
                if (Input.GetMouseButton(0))
                {
                    if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x < -0.05)
                    {
                        transform.Translate(Vector2.left * Time.deltaTime);
                    }
                    else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x > 0.05)
                    {
                        transform.Translate(Vector2.right * Time.deltaTime);
                    }
                }
                if (transform.position.y < -4.7f && !jumping)
                    StartCoroutine("JumpStar");
                yield return null;
            }
        }

        private IEnumerator JumpStar()
        {
            jumping = true;
            rigidbody2D.velocity = (Vector2.up * jumpHeight);
            yield return null;
            jumping = false;
            yield return null;
        }

        private IEnumerator CrushBlock()    // 스킬게이지가 다차고 더블클릭하면 스킬 사용
        {
            bool clicking = false;
            float clickTime = 0;

            while (gameObject.activeSelf)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!clicking || clickTime + 1f < Time.time)
                    {
                        clickTime = Time.time;
                        clicking = true;
                    }
                    else if (clickTime + 0.3f >= Time.time && skillEnergy >= demandEnergy)
                    {
                        rigidbody2D.velocity = (Vector2.down) * skillSpeed;
                        usingSkill = true;
                        clicking = false;
                        skillEnergy -= demandEnergy;
                        GameManager.Instance.Energy = skillEnergy;
                    }
                }
                yield return null;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Block" && usingSkill)  // 스킬 사용 후 닿는 블럭 파괴
            {
                collision.gameObject.SendMessage("CrushBlock");
                usingSkill = false;
            }

            else if (collision.gameObject.tag == "Block" && !jumping)    // 점프하는 중이 아니고 블럭에 닿으면 점프
            {
                StartCoroutine("JumpStar");
                collision.gameObject.SendMessage("CheckHP");
                skillEnergy++;
                GameManager.Instance.Energy = skillEnergy;
            }

            else if (collision.gameObject.tag == "Floor")            // 천장에 닿으면 게임오버
            {
                GameManager.Instance.SendMessage("GameOver");
                Destroy(gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Block" && usingSkill)  // 스킬 사용 후 닿는 블럭 파괴
            {
                collision.gameObject.SendMessage("CrushBlock");
                usingSkill = false;
            }
        }
    }
}