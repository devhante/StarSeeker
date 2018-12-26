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

        // Start is called before the first frame update
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
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
                yield return null;
            }
        }

        private void JumpStar()
        {
            jumping = true;
            rigidbody2D.velocity = (Vector2.up * jumpHeight);
            jumping = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Block" && !jumping)
            {
                JumpStar();
                collision.gameObject.SendMessage("CheckHP");
            }
        }
    }
}