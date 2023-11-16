using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
	[SerializeField] private Button _speedBtn;
	[SerializeField] private Button _timeBtn;
	[SerializeField] private Button _scaleBtn;
	[SerializeField] private Button _plussBtn;

	[SerializeField] private TMP_Text _speedCounter;
	[SerializeField] private TMP_Text _awaitTimeCounter;
	[SerializeField] private TMP_Text _scaleCounter;
	[SerializeField] private TMP_Text _plussCounter;

	private DisplayManager _manager;

	public void Init(DisplayManager manager)
	{
		_manager = manager;

		_speedBtn.onClick.AddListener(UpdateSpeed);
		_timeBtn.onClick.AddListener(UpdateTime);
		_scaleBtn.onClick.AddListener(UpdateScale);
		_plussBtn.onClick.AddListener(UpdatePlussScore);

		manager.OnAwaitTime += AwaitTimeCountScore;
		manager.OnSpeed += SpeedCountScore;
		manager.OnScale += ScaleSizeCount;
		manager.OnPlussScore += PlusScoreCount;
	}

	private void OnDestroy()
	{
		_manager.OnAwaitTime -= AwaitTimeCountScore;
		_manager.OnSpeed -= SpeedCountScore;
		_manager.OnScale -= ScaleSizeCount;
		_manager.OnPlussScore -= PlusScoreCount;
	}

	private void UpdateTime()
	{
		AudioManager.Instance.CkickAudio();

		if (_manager.ScoreCount <= 0) return;

		_manager.UpdateScore(-1);
		_manager.UpdateTime(Constants.AbilityTime);

	}

	private void UpdateSpeed()
	{
		AudioManager.Instance.CkickAudio();

		if (_manager.ScoreCount <= 0) return;
		_manager.UpdateScore(-1);

		float num = _manager.SpeedValue - 1;
		if (num > Mathf.Abs(Constants.SpeedStep))
		{
			_manager.UpdateSpeed(Constants.AbilitySpeed);
		}
	}

	private void UpdateScale()
	{
		AudioManager.Instance.CkickAudio();

		if (_manager.ScoreCount <= 0) return;
		_manager.UpdateScore(-1);

		if (_manager.ScaleValue > Mathf.Abs(Constants.ScaleStep))
		{
			_manager.UpdateScale(Constants.AbilityScale);
		}
	}

	private void UpdatePlussScore()
	{
		AudioManager.Instance.CkickAudio();

		if (_manager.ScoreCount <= 0) return;
		_manager.UpdateScore(-1);
		_manager.UpdatePlussScore(Constants.AbilityPlussScore);
	}

	private void AwaitTimeCountScore(float value) => _awaitTimeCounter.text = Constants.TimeAwaitCounter + Math.Round(value, 1).ToString();

	private void SpeedCountScore(float value) => _speedCounter.text = Constants.BallSpeedCounter + Math.Round(value, 1).ToString();
	
	private void ScaleSizeCount(float value) => _scaleCounter.text = Constants.ScaleSizeCounter + Math.Round(value, 1).ToString();

	private void PlusScoreCount(int value) => _plussCounter.text = Constants.PlusScoreCounter + value.ToString();

}