using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform _target;

    [SerializeField] private float _speed = 2f;
    [SerializeField]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void SetTarget(Transform target)
    {
        _target = target;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerDirection = (_target.position - transform.position).normalized; 
    }
}
