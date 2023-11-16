using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
	[SerializeField] private Button _cancel;
	[SerializeField] private List<GameObject> _views;
	[SerializeField] private Button _rightBtn;
	[SerializeField] private Button _leftBtn;

	private int _curNum = 0;

	private void Start()
	{
		_cancel.onClick.AddListener(CancelClick);
		ActiveView();

		_rightBtn.onClick.AddListener(Right);
		_leftBtn.onClick.AddListener(Left);
	}

	private void Right()
	{
		AudioManager.Instance.CkickAudio();

		if (_curNum >= _views.Count - 1) return;

		_curNum++;

		ActiveView();
	}

	private void Left()
	{
		AudioManager.Instance.CkickAudio();

		if (_curNum <= 0) return;

		_curNum--;
		ActiveView();
	}

	private void ActiveView()
	{
		foreach (var view in _views)
		{
			view.SetActive(false);
		}

		_views[_curNum].SetActive(true);
	}

	private void CancelClick()
	{
		AudioManager.Instance.CkickAudio();
	}
}
