using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject[] backWall;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 5f)
        {
            int kind = Random.Range(0, 3);

            time = 0f;
            GameObject a = Instantiate(backWall[kind]) as GameObject;
            a.transform.position = new Vector3(0f, 5f, 20f);

            int b = Random.Range(0, 6);

            //a.transform.Rotate(new Quaternion.Euler(b*30, 0f, 0f));
            a.transform.rotation = Quaternion.Euler(30f + b * 60, -90f, 90f);
        }
        else
        {
            time += Time.deltaTime;
        }
        
    }
}
