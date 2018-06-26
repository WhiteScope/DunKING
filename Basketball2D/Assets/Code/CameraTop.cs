using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTop : MonoBehaviour
{
    private bool inTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = true;
            if (transform.parent.transform.position.y <= -0.04)
            {
                StartCoroutine(CameraMovment());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }

    private IEnumerator CameraMovment()
    {
        while (inTrigger)
        {
            transform.parent.transform.position = Vector3.Lerp(transform.parent.transform.position, new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + 0.05f, transform.parent.transform.position.z), 1);
            yield return new WaitForEndOfFrame();
        }
    }
}