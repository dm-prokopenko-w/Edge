using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Preloader : MonoBehaviour
{
	[SerializeField] private Image _bar;
	[SerializeField] private TMP_Text _timer;
	[SerializeField] private GameObject _body;

	private void Start()
	{
		_body.SetActive(true);

		StartCoroutine(Loader());
	}

	private IEnumerator Loader()
	{
		float curT = 0;
		float t = 0;

		while (true)
		{
			t = Random.Range(0, 0.05f);
			curT += t;
			_timer.text = ((int)(curT * 100f)) + "%";
			_bar.fillAmount = curT;
			yield return new WaitForSeconds(t * 3);

			if (curT > 1)
			{
				_body.SetActive(false);
				break;
			}
		}
	}
}