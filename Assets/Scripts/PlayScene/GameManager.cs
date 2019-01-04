using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarSeeker.GameScene
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField] private GameObject block;
        [SerializeField] private float blockMakeTerm;

        private int stage;
        private bool gameover = false;

        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine("MakeBlock");
            stage = 0;
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private IEnumerator MakeBlock()
        {
            while (!gameover)
            {
                for (float i = -2.44f; i < 2.5f; i += 0.7f)
                    Instantiate(block, new Vector2(i, -5), Quaternion.Euler(0, 0, 0));

                stage++;
                yield return new WaitForSeconds(blockMakeTerm);
            }
        }
        
        private void GameOver()
        {
            gameover = true; 
        }

        public int GetStage()
        {
            return stage;
        }

        public bool GetGameOVer()
        {
            return gameover;
        }
    }
}