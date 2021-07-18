using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector3 dir;

    bool isGo = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGo)
        {
            transform.Translate(dir * 0.01f);

        }

    }


    public void DecideDirection(Vector3 dir)
    {
        this.dir = dir;
        isGo = true;
    }
}
