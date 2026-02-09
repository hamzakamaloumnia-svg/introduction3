using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.LogWarning("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("Update");

    }
}
