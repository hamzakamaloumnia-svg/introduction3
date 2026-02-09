using UnityEngine;

public class CapsuleCompagnio : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    [SerializeField] private float _lerpSpeed = 5f;
    [SerializeField] private Vector3 offset;


    // Update is called once per frame
    void Start()
    {
        int a = (-1)%4;
            Debug.Log(a);
    }
}
