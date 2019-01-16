using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarSeeker.GameScene
{
    public class PlaySceneUI : MonoBehaviour
    {
        [SerializeField] private Text StageText;    // 올라온 블럭들
        [SerializeField] private Text energyText;   // 현재 에너지
        [SerializeField] private Image touchEffect;   // 터치이펙트

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            StageText.text = "바닥 수 : " + GameManager.Instance.GetStage();
            energyText.text = "에너지 : " + GameManager.Instance.Energy;
            if (Input.GetMouseButton(0))
            {
                touchEffect.gameObject.SetActive(true);
                touchEffect.transform.position = Input.mousePosition;
            }
            else
                touchEffect.gameObject.SetActive(false);
        }
    }
}
