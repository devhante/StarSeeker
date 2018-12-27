using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarSeeker.Components
{
	public class SceneTitle : MonoBehaviour
	{
		[SerializeField]
		private Text text;

		[SerializeField]
		private readonly string sceneTitle;

		private void Start()
		{
			text.text = sceneTitle;
		}
	}

}
