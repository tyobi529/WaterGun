using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Canvasで適当にImageをたくさん作って配列に入れてください
    //public Transform[] Image;

    private float width;
    private float height;


    private float touchLeft;
    private float touchRight;

    private float angleLeft;
    private float angleRight;


    [SerializeField] Rigidbody rigid;


    [SerializeField] float power = 2f;


    [SerializeField] LineRenderer lineLeft;
    [SerializeField] LineRenderer lineRight;


    [SerializeField] float limitSpeed = 7f;


    [SerializeField] BubbleGenerator bubbleGenerator;
    [SerializeField] GameObject bubble;



    [SerializeField] GameObject bullet;

    private void Start()
    {
        width = Screen.width;
        height = Screen.height;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            //touchCountが0のときに呼ばれるとエラーでます
            //このフレームでのタッチ情報を取得
            Touch[] myTouches = Input.touches;


            //Debug.Log("タップ" + Input.touchCount);


            touchLeft = 0f;
            touchRight = 0f;

            //検出されている指の数だけ回して
            //指の位置にImageを移動
            for (int i = 0; i < myTouches.Length; i++)
            {
                //Image[i].position = myTouches[i].position;

                if (myTouches[i].position.x < width / 2f)
                {
                    touchLeft = myTouches[i].position.y / height;
                }

                if (myTouches[i].position.x > width / 2f)
                {
                    touchRight = myTouches[i].position.y / height;
                }
            }

            //Debug.Log("left " + touchLeft);
            //Debug.Log("right " + touchRight);


            //if (myTouches.Length == 2)
            //{
            //    touchLeft = myTouches[0].position.y / height;
            //    touchRight = myTouches[1].position.y / height;

            //    Debug.Log("left " + touchLeft);
            //    Debug.Log("right " + touchRight);
            //}


            //力を加える
            if (touchLeft > 0f || touchRight > 0f)
            {
                angleLeft = 180f * touchLeft;
                angleRight = 180f * touchRight;

                //Debug.Log("angleLeft" + angleLeft);
                //Debug.Log("angleRight" + angleRight);

                //Debug.Log("left" + Mathf.Sin(angleLeft));


                Vector3 dirLeft = new Vector3(-Mathf.Sin(angleLeft* Mathf.Deg2Rad), -Mathf.Cos(angleLeft* Mathf.Deg2Rad), 0f);
                Vector3 dirRight = new Vector3(Mathf.Sin(angleRight* Mathf.Deg2Rad), -Mathf.Cos(angleRight* Mathf.Deg2Rad), 0f);

                //Debug.Log("Left " + dirLeft.ToString("F4"));
                //Debug.Log("Right " + dirRight.ToString("F4"));

                rigid.AddForce(dirLeft * -1f * power);
                rigid.AddForce(dirRight * -1f * power);

                //一定速度を超えたら加速しない
                if (rigid.velocity.magnitude > limitSpeed)
                {
                    rigid.velocity = rigid.velocity.normalized * limitSpeed;
                }
 

 

                if (touchLeft > 0f)
                {
                    lineLeft.enabled = true;
                    //作用方向の表示
                    var positionsLeft = new Vector3[]{
                    new Vector3(0, 1, 0),               // 開始点
                    dirLeft*3f              // 終了点
                     };
                    lineLeft.SetPositions(positionsLeft);


                    //泡生成
                    //GameObject a = Instantiate(bubble) as GameObject;
                    //a.transform.position = transform.position;
                    ////方向
                    //a.GetComponent<BubbleController>().DecideDirection(dirLeft);


                    ////玉生成
                    //GameObject a = Instantiate(bullet) as GameObject;
                    //a.transform.position = transform.position;
                    ////方向
                    //a.GetComponent<BulletController>().DecideDirection(dirLeft);

                    //ビーム
                    //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
                    //Ray ray = new Ray(transform.position, dirLeft);

                    ////Rayが当たったオブジェクトの情報を入れる箱
                    //RaycastHit hit;

                    ////Rayの飛ばせる距離
                    //int distance = 5;

                    ////Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
                    //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

                    ////もしRayにオブジェクトが衝突したら
                    ////                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
                    //if (Physics.Raycast(ray, out hit, distance))
                    //{
                    //    //Rayが当たったオブジェクトのtagがPlayerだったら
                    //    //if (hit.collider.tag == "Player")
                    //    //    Debug.Log("RayがPlayerに当たった");

                    //    Debug.Log("あたった");


                    //}


                }
                else
                {
                    lineLeft.enabled = false;
                }

                if (touchRight > 0f)
                {
                    lineRight.enabled = true;
                    var positionsRight = new Vector3[]{
                    new Vector3(0, 1, 0),               // 開始点
                    dirRight*3f               // 終了点
                     };

                    lineRight.SetPositions(positionsRight);

                }
                else
                {
                    lineRight.enabled = false;
                }





   


                //lineLeft.SetPosition(1, dirLeft);

            }



        }
        else
        {
            lineLeft.enabled = false;
            lineRight.enabled = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "BackWall")
    //    {
    //        Debug.Log("out");

    //    }

    //    //Debug.Log("out");

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BackWall")
        {
            Debug.Log("あたった");

        }

        //Debug.Log("out");
    }



}