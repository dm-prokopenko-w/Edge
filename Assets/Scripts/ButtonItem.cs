using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
	[SerializeField] private GameManager _gameManager;

	[SerializeField] private Dir _dir;
	[SerializeField] private Button _btn;
	[SerializeField] private TMP_Text _counter;

	private void Start()
	{
		_btn.onClick.AddListener(Click);
		_gameManager.OnChangeTime += ChangeTime;
	}

	private void OnDestroy()
	{
		_gameManager.OnChangeTime -= ChangeTime;
	}

	private void ChangeTime(float time, Dir dir)
	{
		var num = (int)time;
		_counter.text = num.ToString();
		if (time <= 0)
		{
			_btn.interactable = true;
			_counter.gameObject.SetActive(false);
		}
		else
		{
			_btn.interactable = false;
			_counter.gameObject.SetActive(dir == _dir);
		}
	}

	private void Click()
	{
		_gameManager.Click(_dir);
		AudioManager.Instance.CkickAudio();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		_gameManager.OnTriggerWithBall();
	}
}