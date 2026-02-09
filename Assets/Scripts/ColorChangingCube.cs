using System;
using UnityEngine;


public class ColorChangingCube : MonoBehaviour
{

    public MeshRenderer meshRenderer;

    float timer = 0f;

    [Range(0.5f, 3f)]
    [SerializeField] private float minTimer = 0.5f;
    [SerializeField] private float maxTimer = 3f;
    [SerializeField] private string testString = "true";

    [SerializeField] private MyFirstScript myFirstScript;

    [SerializeField] private Vector3 _velocity;

    private float currentTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeColor();
    }

    private void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= currentTimer)
        {
            ChangeColor();
        }

        transform.position += _velocity * Time.deltaTime;
    }

    void ChangeColor ()
    {
        timer = 0f;
        currentTimer = UnityEngine.Random.Range(minTimer, maxTimer);

        int randomNumber = UnityEngine.Random.Range(0, 2);

        // Change the color of the cube depending of the random number
        if (randomNumber == 0)
        {
            ChangeRendererColor(Color.red);
        }
        else
        {
            ChangeRendererColor(Color.blue);
        }
    }

    void ChangeRendererColor (Color color)
    {
        meshRenderer.material.color = color;
    }
}
