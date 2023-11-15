using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour
{
	[SerializeField] private TMP_Text _scoreCounter;
	[SerializeField] private TMP_Text _awaitTimeCounter;
	[SerializeField] private TMP_Text _speedCounter;

	[SerializeField] private Button _menuBtn;

	public void Init(Action<bool> onPlay, DisplayManager display)
	{
		display.OnScore += UpdateCountScore;
		display.OnAwaitTime += AwaitTimeCountScore;
		display.OnSpeed += SpeedCountScore;

		_menuBtn.onClick.AddListener(() => Menu(onPlay));
	}

	private void Menu(Action<bool> onPlay)
	{
		AudioManager.Instance.CkickAudio();
		onPlay?.Invoke(false);
	}

	private void UpdateCountScore(int value)	=> _scoreCounter.text = Constants.ScoreCounter + value.ToString();

	private void AwaitTimeCountScore(float value) => _awaitTimeCounter.text = Constants.TimeAwaitCounter + Math.Round(value, 1).ToString();

	private void SpeedCountScore(float value) => _speedCounter.text = Constants.BallSpeedCounter + Math.Round(value, 1).ToString();
}
