using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliderhorizontal : MonoBehaviour
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
        if (Mathf.Round(transform.position.x) == Mathf.Round(TargetPosition.transform.position.x))
        {
            TargetPosition.transform.position = new Vector2(startPosition.x, TargetPosition.transform.position.y);
            startPosition.x = Mathf.Round(transform.position.x);
        }
    }
}