using System;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameMenu _menu;
	[SerializeField] private TopPanel _topPanel;
	[SerializeField] private BottomPanel _bottomPanel;

	[SerializeField] private Ball _ball;

	public Action<bool> OnPlay;

	public Action<float, Dir> OnChangeTime;
	private Dir _currentDir;
	private bool _isPlay = false;
	private Random _random = new Random();
	private float _currentTime = 0f;
	private bool _isPlayingTimer = false;

	private DisplayManager _displayManager = new DisplayManager();

	private void Start()
	{
		OnPlay += ActivePlay;

		_menu.Init(OnPlay, _displayManager);

		_topPanel.Init(OnPlay, _displayManager);
		_bottomPanel.Init(_displayManager);
		_displayManager.OnScale += _ball.UpdateScale;

		_displayManager.Init();
	}

	public void OnTriggerWithBall() => OnPlay?.Invoke(false);

	private void ActivePlay(bool value)
	{
		_isPlay = value;
		_menu.ActiveBodyMenu(value);

		if (value)
		{
			_isPlayingTimer = true;
			_currentDir = (Dir)_random.Next(1, 5);
		}
		else
		{
			_isPlayingTimer = true;

			_currentDir = Dir.None;
			_ball.UpdatePos();
		}
	}

	public void Click(Dir dir)
	{
		if (_currentDir != dir) return;

		_currentDir = (Dir)_random.Next(1, 5);
		_ball.UpdatePos();
		_isPlayingTimer = true;
		_ball.gameObject.SetActive(false);

		_displayManager.UpdateOnClick();
	}

	private void Update()
	{
		if (!_isPlay) return;

		if (_isPlayingTimer)
		{
			_currentTime += Time.deltaTime;
			OnChangeTime?.Invoke(_displayManager.TimeAwaitCount - _currentTime, _currentDir);

			if (_currentTime > _displayManager.TimeAwaitCount)
			{
				_ball.gameObject.SetActive(true);
				_currentTime = 0f;
				_isPlayingTimer = false;
			}
		}
		else
		{
			_ball.Move(GetDir());
		}
	}

	private Vector3 GetDir()
	{
		switch (_currentDir)
		{
			case Dir.Left:
				return Vector3.left * _displayManager.SpeedValue;
			case Dir.Right:
				return Vector3.right * _displayManager.SpeedValue;
			case Dir.Up:
				return Vector3.up * _displayManager.SpeedValue;
			case Dir.Down:
				return Vector3.down * _displayManager.SpeedValue;
			default:
				return Vector3.zero;
		}
	}

	private void OnDestroy()
	{
		OnPlay -= ActivePlay;
		_displayManager.OnScale -= _ball.UpdateScale;
	}
}
