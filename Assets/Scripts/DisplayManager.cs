using System;
using UnityEngine;

public class DisplayManager
{
	public Action<int> OnScore;

	public Action<float> OnAwaitTime;
	public Action<float> OnSpeed;
	public Action<float> OnScale;
	public Action<int> OnPlussScore;

	private int _scoreCount = 0;
	private float _timeAwait = 5f;
	private float _speed = 1f;
	private float _scale = 1f;
	private int _pluss = 1;

	private int _curScaleStep = 0;

	private int _maxScaleStep = 5;

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

		_scale = PlayerPrefs.GetFloat(Constants.ScaleCount);
		if (_scale <= 0)
		{
			_scale = Constants.DefScale;
		}
		OnScale?.Invoke(_scale);

		_pluss = PlayerPrefs.GetInt(Constants.PlussScoreCount);
		if (_pluss <= 0)
		{
			_pluss = Constants.DefPluss;
		}
		OnPlussScore?.Invoke(_pluss);
	}

	public int ScoreCount => _scoreCount;
	public float TimeAwaitCount => _timeAwait;
	public float SpeedValue => _speed;
	public float ScaleValue => _scale;

	public void UpdateOnClick()
	{
		UpdateScore(_pluss);
		UpdateTime(Constants.TimeStep);
		UpdateSpeed(Constants.SpeedStep);

		_curScaleStep++;
		if (_curScaleStep >= _maxScaleStep)
		{
			_curScaleStep = 0;
			UpdateScale(Constants.ScaleStep);
		}
	}

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

	public void UpdateScale(float count)
	{
		if (_scale <= Constants.MinScale || _scale >= Constants.MaxScale) return;
		_scale += count;
		OnScale?.Invoke(_scale);
		PlayerPrefs.SetFloat(Constants.ScaleCount, _scale);
	}

	public void UpdatePlussScore(int count)
	{
		_pluss += count;
		OnPlussScore?.Invoke(_pluss);
		PlayerPrefs.SetInt(Constants.PlusScoreCounter, _pluss);
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

		_pluss = Constants.DefPluss;
		OnPlussScore?.Invoke(_pluss);
		PlayerPrefs.SetFloat(Constants.PlussScoreCount, _pluss);

		_scale = Constants.DefScale;
		OnScale?.Invoke(_scale);
		PlayerPrefs.SetFloat(Constants.ScaleCount, _scale);
	}
}