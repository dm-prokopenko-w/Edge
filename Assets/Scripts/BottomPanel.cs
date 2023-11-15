using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
	[SerializeField] private Button _speedBtn;
	[SerializeField] private Button _timeBtn;
	private DisplayManager _manager;

	public void Init(DisplayManager manager)
	{
		_manager = manager;

		_speedBtn.onClick.AddListener(UpdateSpeed);
		_timeBtn.onClick.AddListener(UpdateTime);
	}

	private void UpdateTime()
	{
		AudioManager.Instance.CkickAudio();
		_manager.UpdateTime(Constants.AbilityTime);
	}

	private void UpdateSpeed()
	{
		AudioManager.Instance.CkickAudio();

		float num = _manager.SpeedValue - 1;
		if (num > Mathf.Abs(Constants.SpeedStep))
		{
			_manager.UpdateSpeed(Constants.AbilitySpeed);
		}
	}
}