using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <=Mathf.Epsilon) return;

        float cycles = Time.time / period; // Continually growing over time

        const float tau = Mathf.PI * 2; // Constant value of pi*2
        float rawSineWave = Mathf.Sin(cycles * tau); // Going from -1 to 1
        movementFactor = (rawSineWave + 1f) / 2f; // Going from 0 to 1 so it's cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
