using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVertical : MonoBehaviour
{
    public GameObject TargetPosition;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPosition.transform.position, 0.5f * Time.deltaTime);
        if (Mathf.Round(transform.position.y) == Mathf.Round(TargetPosition.transform.position.y))
        {
            TargetPosition.transform.position = new Vector2(TargetPosition.transform.position.x, startPosition.y);
            startPosition.y = Mathf.Round(transform.position.y);
        }
    }
}