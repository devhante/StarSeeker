using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StarSeeker.IntroScene
{
	public class IntroSceneManager : MonoBehaviour
	{
		public static IntroSceneManager Instance { get; private set; }

		private void Awake()
		{
			if (Instance == null) Instance = this;
			else Destroy(gameObject);
		}

		private void Start()
		{
			StartCoroutine("TempCoroutine");
		}

		private IEnumerator TempCoroutine()
		{
			yield return new WaitForSeconds(3);
			SceneManager.LoadScene("MainScene");
		}
	}
}