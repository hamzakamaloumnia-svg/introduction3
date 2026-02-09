using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    // The list of points the Capsule is goint to move to
    [SerializeField] private List<Transform> waypoints;

    [SerializeField] private AnimationCurve _horizontalCurve;
    [SerializeField] private AnimationCurve _verticalCurve;
    [SerializeField] private  float height = 5f;
    // The Capsule's movement speed
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _duration = 3f;
    private float _timer = 0f;

    // The acceptable distance to consider we arrived at the next point
    [SerializeField] private float _distance = 0.1f;

    // The acceptable distance to consider we arrived at the next point
    [SerializeField] private int _startIndex = 0;

    // The current waypoints index
    private int currentIndex = 1;
    private Vector3 nextPoint;
    private int nextIndex;
    private Vector3 currentPoint;


    private void Awake()
    {
        // Set the Capsule in Awake to allows the camera to have the correct position
        transform.position = waypoints[_startIndex].position;

        SetIndexes(currentIndex);
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        // Get the next point in the list
        // We could do it only when changing index but it won't refresh when we move them during playmode
        currentPoint = waypoints[currentIndex].position;
        nextPoint = waypoints[nextIndex].position;

        float progress = _timer / _duration;

        Vector3 nextPosition = Vector3.Lerp(currentPoint, nextPoint, _horizontalCurve.Evaluate(progress));
        nextPosition.y = _verticalCurve.Evaluate(progress) * height;



        transform.position = nextPosition;

        // We move the player position towards the next point at _speed
        //transform.position = Vector3.MoveTowards(transform.position, nextPoint, _speed * Time.deltaTime);

        // Rotate the player to lookAt the next point
        transform.LookAt(new Vector3(nextPoint.x, nextPosition.y, nextPoint.z), Vector3.up);

        // Check if the Distance to the nextPoint is acceptable
        if (progress>=1)
        {
            SetIndexes(currentIndex + 1);
        }
    }

    private void SetIndexes(int newIndex)
    {
        currentIndex = newIndex % waypoints.Count;
        nextIndex = (newIndex + 1) % waypoints.Count;
        _timer = 0;
    }
}
