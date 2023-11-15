using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject _click;

    private List<GameObject> _audios = new List<GameObject>();

	public static AudioManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void CkickAudio()
    {
        var audio = _audios.Find(x => x.name.Equals(_click.name));

		if (audio == null || audio.activeSelf)
        {
			audio = Instantiate(_click);
            audio.transform.SetParent(transform);
			audio.name = _click.name;
			_audios.Add(audio);
            return;
		}

        audio.SetActive(true);
	}
}
