using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;

    private float difX;
    private float difY;


    // Start is called before the first frame update
    void Start()
    {
        difX = transform.position.x - player.transform.position.x;
        difY = transform.position.y - player.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + difX, player.transform.position.y + difY, -10f);
    }
}
