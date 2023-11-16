using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
	[SerializeField] private Button _playBtn;
	[SerializeField] private Button _resetBtn;
	[SerializeField] private Button _quitBtn;
	[SerializeField] private GameObject _body;
	[SerializeField] private TMP_Text _recordText;

	private DisplayManager _display;

	public void Init(Action<bool> onPlay, DisplayManager display)
	{
		_playBtn.onClick.AddListener(() => Play(onPlay));
		_resetBtn.onClick.AddListener(RemoveSave);
		_quitBtn.onClick.AddListener(Quit);

		ActiveBodyMenu(false);
		_display = display;

		display.OnRecord += UpdateRecord;
	}

	private void UpdateRecord(int count) => _recordText.text = Constants.YourRecord + count;

	private void Play(Action<bool> onPlay)
	{
		AudioManager.Instance.CkickAudio();
		onPlay?.Invoke(true);
	}

	public void ActiveBodyMenu(bool value) => _body.SetActive(!value);

	private void RemoveSave()
	{
		AudioManager.Instance.CkickAudio();
		_display.RemoveSave();
	}

	private void Quit()
	{
		_display.OnRecord -= UpdateRecord;

		AudioManager.Instance.CkickAudio();
		Application.Quit();
	}
}