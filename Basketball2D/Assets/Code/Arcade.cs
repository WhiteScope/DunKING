using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arcade : MonoBehaviour
{
    public GameObject[] Ebenen;
    private Queue<GameObject> CurrentGameobj;
    public Text Score;

    private Vector3 p;
    private float abstand = 10;
    private float abstandMultiplikator;
    private int howManyActive;
    private int score;

    private void Start()
    {
        CurrentGameobj = new Queue<GameObject>();
        for (int i = 0; i <= 3; i++)
        {
            SpawnGameobject();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
        }
        if (Basket.triggered)
        {
            SpawnGameobject();
            score++;
            Score.text = "Score:  " + score;
            Basket.triggered = false;
        }
        if (howManyActive == 10)
        {
            DestroyObject(CurrentGameobj.Dequeue());
            howManyActive--;
        }
    }

    public void SpawnGameobject()
    {
        CurrentGameobj.Enqueue(Instantiate(Ebenen[Random.Range(0, Ebenen.Length)], new Vector3(0, 0 - abstand * abstandMultiplikator, 0), Quaternion.identity));
        abstandMultiplikator++;
        howManyActive++;
    }
}