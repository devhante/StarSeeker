using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarSeeker.Components
{
	public class SelectableScrollList : MonoBehaviour
	{
		[SerializeField]
		private Sprite[] selectSprites;

		[SerializeField]
		private int selectButtonHeight;

		private Button[] selectButtons;

		private void Start()
		{
			foreach (var item in selectSprites)
			{
				var sprite = Instantiate(new GameObject(), transform);
				sprite.AddComponent<Image>().sprite = item;

				var button = Instantiate(new GameObject(), sprite.transform);
				var buttonRT = button.AddComponent<RectTransform>();
				buttonRT.anchorMin = Vector2.up;
				buttonRT.anchorMax = Vector2.up;
			}
		}
	}
}

