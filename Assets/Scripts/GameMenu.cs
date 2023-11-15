using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _resetBtn;
    [SerializeField] private Button _quitBtn;
    [SerializeField] private GameObject _body;

    public void Init(Action<bool> onPlay, DisplayManager display)
    {
		_playBtn.onClick.AddListener(() => onPlay?.Invoke(true));
		_resetBtn.onClick.AddListener(display.RemoveSave);
		_quitBtn.onClick.AddListener(Quit);

		ActiveBodyMenu(false);
	}

	public void ActiveBodyMenu(bool value)
	{
		_body.SetActive(!value);
	}

	private void Quit()
	{
		Application.Quit();
	}
}