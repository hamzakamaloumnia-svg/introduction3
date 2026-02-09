using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform _target;

    public float _lerpSpeed = 5f;

    private void Start()
    {
        // Set the Camera position to the target position at startup
        transform.position = _target.position;
    }

    private void LateUpdate()
    {
        // Smooth the current position to the target position
        transform.position = Vector3.Lerp(transform.position, _target.position, _lerpSpeed * Time.deltaTime);
    }
}
