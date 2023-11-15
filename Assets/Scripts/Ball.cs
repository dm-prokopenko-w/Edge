using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rb;

	public void Move(Vector3 dir) => _rb.velocity = dir;

	public void UpdatePos()
	{
		Move(Vector3.zero);
		transform.localPosition = Vector3.zero;
	}
}
