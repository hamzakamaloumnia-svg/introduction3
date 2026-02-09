using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector3 _direction;
    public float _lifeTime = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Shoot(Vector3 direction)
    {
        _direction = direction;
        Debug.Log("asset");
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.position += _direction*_speed*Time.deltaTime;
    }
}
