using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour
{
	[SerializeField] private TMP_Text _scoreCounter;

	[SerializeField] private Button _menuBtn;

	public void Init(Action<bool> onPlay, DisplayManager display)
	{
		display.OnScore += UpdateCountScore;

		_menuBtn.onClick.AddListener(() => Menu(onPlay));
	}

	private void Menu(Action<bool> onPlay)
	{
		AudioManager.Instance.CkickAudio();
		onPlay?.Invoke(false);
	}

	private void UpdateCountScore(int value)	=> _scoreCounter.text = Constants.ScoreCounter + value.ToString();

}
