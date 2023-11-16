using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioSource _back;
	[SerializeField] private AudioSource _click;

	[SerializeField] private Slider _musicSlider;
	[SerializeField] private Slider _soundSlider;

	[SerializeField] private Button _cancel;
	[SerializeField] private GameObject _body;

	private List<AudioSource> _audios = new List<AudioSource>();

	public static AudioManager Instance { get; private set; }

	private float _soundValue;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		if (!PlayerPrefs.HasKey(Constants.MusicKey))
		{
			_musicSlider.value = 0.1f;
			PlayerPrefs.SetFloat(Constants.MusicKey, _musicSlider.value);
		}
		else
		{
			_musicSlider.value = PlayerPrefs.GetFloat(Constants.MusicKey);
		}
		_back.volume = _musicSlider.value;

		if (!PlayerPrefs.HasKey(Constants.SoundKey))
		{
			_soundSlider.value = 1f;
			PlayerPrefs.SetFloat(Constants.SoundKey, _soundSlider.value);
		}
		else
		{
			_soundSlider.value = PlayerPrefs.GetFloat(Constants.SoundKey);
		}
		_soundValue = _soundSlider.value;

		_musicSlider.onValueChanged.AddListener(delegate { _back.volume = _musicSlider.value; });
		_soundSlider.onValueChanged.AddListener(delegate { _soundValue = _soundSlider.value; });

		_cancel.onClick.AddListener(CancelClick);
	}

	private void CancelClick()
	{
		CkickAudio();
		PlayerPrefs.SetFloat(Constants.MusicKey, _musicSlider.value);
		PlayerPrefs.SetFloat(Constants.SoundKey, _soundSlider.value);
	}

	public void CkickAudio()
	{
		var audio = _audios.Find(x => x.gameObject.name.Equals(_click.gameObject.name));

		if (audio == null || audio.gameObject.activeSelf)
		{
			audio = Instantiate(_click);
			audio.volume = _soundValue;
			audio.transform.SetParent(transform);
			audio.gameObject.name = _click.name;
			_audios.Add(audio);
			return;
		}

		audio.volume = _soundValue;
		audio.gameObject.SetActive(true);
	}
}
