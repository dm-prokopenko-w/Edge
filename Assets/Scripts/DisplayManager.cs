using System;
using UnityEngine;

public class DisplayManager
{
	public Action<int> OnScore;
	public Action<float> OnAwaitTime;
	public Action<float> OnSpeed;

	private int _scoreCount = 0;
	private float _timeAwait = 5f;
	private float _speed = 1f;

	public void Init()
	{
		_scoreCount = PlayerPrefs.GetInt(Constants.ScoreCount);
		OnScore?.Invoke(_scoreCount);

		_timeAwait = PlayerPrefs.GetFloat(Constants.TimeAwaitCount);
		if (_timeAwait <= 0)
		{
			_timeAwait = Constants.DefTime;
		}
		OnAwaitTime?.Invoke(_timeAwait);

		_speed = PlayerPrefs.GetFloat(Constants.BallSpeedCount);
		if (_speed <= 0)
		{
			_speed = Constants.DefSpeed;
		}
		OnSpeed?.Invoke(_speed);
	}

	public float TimeAwaitCount => _timeAwait;
	public float SpeedValue => _speed;

	public void UpdateScore(int count)
	{
		_scoreCount += count;
		OnScore?.Invoke(_scoreCount);
		PlayerPrefs.SetInt(Constants.ScoreCount, _scoreCount);
	}

	public void UpdateTime(float count)
	{
		if (_timeAwait <= Math.Abs(Constants.TimeStep)) return;
		_timeAwait += count;
		OnAwaitTime?.Invoke(_timeAwait);
		PlayerPrefs.SetFloat(Constants.TimeAwaitCount, _timeAwait);
	}

	public void UpdateSpeed(float count)
	{
		if (_speed <= Math.Abs(Constants.SpeedStep)) return;
		_speed += count;
		OnSpeed?.Invoke(_speed);
		PlayerPrefs.SetFloat(Constants.BallSpeedCount, _speed);
	}

	public void RemoveSave()
	{
		AudioManager.Instance.CkickAudio();

		_scoreCount = Constants.DefScore;
		OnScore?.Invoke(_scoreCount);
		PlayerPrefs.SetInt(Constants.ScoreCount, _scoreCount);

		_timeAwait = Constants.DefTime;
		OnAwaitTime?.Invoke(_timeAwait);
		PlayerPrefs.SetFloat(Constants.TimeAwaitCount, _timeAwait);

		_speed = Constants.DefSpeed;
		OnSpeed?.Invoke(_speed);
		PlayerPrefs.SetFloat(Constants.BallSpeedCount, _speed);
	}
}