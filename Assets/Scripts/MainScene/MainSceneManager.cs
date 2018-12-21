using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StarSeeker.MainScene
{
	public class MainSceneManager : MonoBehaviour
	{
		public static MainSceneManager Instance { get; private set; }

		public Button MapSelectSceneButton;
		public Button AchievementSceneButton;
		public Button SettingsSceneButton;
		public Button RankingSceneButton;
		public Button ShopSceneButton;
		public Button GardenSceneButton;
		public Button PlaySceneButton;

		private void Awake()
		{
			if (Instance == null) Instance = this;
			else Destroy(gameObject);
		}

		private void Start()
		{
			MapSelectSceneButton.onClick.AddListener(OnClickMapSelectSceneButton);
			AchievementSceneButton.onClick.AddListener(OnClickAchievementSceneButton);
			SettingsSceneButton.onClick.AddListener(OnClickSettingsSceneButton);
			RankingSceneButton.onClick.AddListener(OnClickRankingSceneButton);
			ShopSceneButton.onClick.AddListener(OnClickShopSceneButton);
			GardenSceneButton.onClick.AddListener(OnClickGardenSceneButton);
			PlaySceneButton.onClick.AddListener(OnClickPlaySceneButton);
		}

		private void OnClickMapSelectSceneButton()
		{
			SceneManager.LoadScene("MapSelectScene");
		}

		private void OnClickAchievementSceneButton()
		{
			SceneManager.LoadScene("AchievementScene");
		}

		private void OnClickSettingsSceneButton()
		{
			SceneManager.LoadScene("SettingsScene");
		}

		private void OnClickRankingSceneButton()
		{
			SceneManager.LoadScene("RankingScene");
		}

		private void OnClickShopSceneButton()
		{
			SceneManager.LoadScene("ShopScene");
		}

		private void OnClickGardenSceneButton()
		{
			SceneManager.LoadScene("GardenScene");
		}

		private void OnClickPlaySceneButton()
		{
			SceneManager.LoadScene("PlayScene");
		}
	}
}
