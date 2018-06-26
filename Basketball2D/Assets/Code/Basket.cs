using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // public GameObject ParentGate;

    public GameObject Gate2;
    public GameObject Gate1;
    public GameObject FixPoint1;
    public GameObject FixPoint2;
    private AudioSource success;

    public static bool triggered;

    private void Start()
    {
        success = GetComponent<AudioSource>();
        //Gate1 = ParentGate.transform.GetChild(0).gameObject;
        //Gate2 = ParentGate.transform.GetChild(1).gameObject;
        //FixPoint1 = ParentGate.transform.GetChild(2).gameObject;
        //FixPoint2 = ParentGate.transform.GetChild(3).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(OpenGate(Gate1, Gate2, FixPoint1, FixPoint2));
            triggered = true;
            GetComponent<Collider2D>().enabled = false;
            success.Play();
        }
    }

    private IEnumerator OpenGate(GameObject Gate1, GameObject Gate2, GameObject FixPoint1, GameObject FixPoint2)
    {
        while (Gate1.transform.position != FixPoint1.transform.position && Gate2.transform.position != FixPoint2.transform.position)
        {
            Gate1.transform.position = Vector3.Lerp(FixPoint1.transform.position, Gate1.transform.position, 0.5f);
            Gate2.transform.position = Vector3.Lerp(FixPoint2.transform.position, Gate2.transform.position, 0.5f);
            yield return new WaitForEndOfFrame();
        }
    }
}