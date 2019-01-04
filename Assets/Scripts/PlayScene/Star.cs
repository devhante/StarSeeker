using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarSeeker.GameScene
{
    public class Star : MonoBehaviour
    {
        [SerializeField] private float jumpHeight = 1;

        private Rigidbody2D rigidbody2D;
        private bool jumping = false;
        private List<GameObject> babyStars;

        // Start is called before the first frame update
        private void Start()
        {
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.freezeRotation = true;
            StartCoroutine("MoveStar");
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private IEnumerator MoveStar()
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Block" && !jumping)
            {
                StartCoroutine("JumpStar");
                collision.gameObject.SendMessage("CheckHP");
            }

            else if(collision.gameObject.tag == "Floor")
            {
                GameManager.Instance.SendMessage("GameOver");
                Destroy(gameObject);
            }
        }
    }
}