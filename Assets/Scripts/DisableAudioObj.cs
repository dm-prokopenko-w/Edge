using System.Threading.Tasks;
using UnityEngine;

public class DisableAudioObj : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private float _time;

    private void Start()
    {
        _time = _audioClip.length;
		Disable();
	}

	private void OnEnable()
	{
		Disable();
	}

	public async void Disable()
	{
		int t = (int)(_time * 1000 + 500);
		await Task.Delay(t);
		gameObject.SetActive(false);
	}
}
