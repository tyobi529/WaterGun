using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Canvas�œK����Image�������������Ĕz��ɓ���Ă�������
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
            //touchCount��0�̂Ƃ��ɌĂ΂��ƃG���[�ł܂�
            //���̃t���[���ł̃^�b�`�����擾
            Touch[] myTouches = Input.touches;


            //Debug.Log("�^�b�v" + Input.touchCount);


            touchLeft = 0f;
            touchRight = 0f;

            //���o����Ă���w�̐������񂵂�
            //�w�̈ʒu��Image���ړ�
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


            //�͂�������
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

                //��葬�x�𒴂�����������Ȃ�
                if (rigid.velocity.magnitude > limitSpeed)
                {
                    rigid.velocity = rigid.velocity.normalized * limitSpeed;
                }
 

 

                if (touchLeft > 0f)
                {
                    lineLeft.enabled = true;
                    //��p�����̕\��
                    var positionsLeft = new Vector3[]{
                    new Vector3(0, 1, 0),               // �J�n�_
                    dirLeft*3f              // �I���_
                     };
                    lineLeft.SetPositions(positionsLeft);


                    //�A����
                    //GameObject a = Instantiate(bubble) as GameObject;
                    //a.transform.position = transform.position;
                    ////����
                    //a.GetComponent<BubbleController>().DecideDirection(dirLeft);


                    ////�ʐ���
                    //GameObject a = Instantiate(bullet) as GameObject;
                    //a.transform.position = transform.position;
                    ////����
                    //a.GetComponent<BulletController>().DecideDirection(dirLeft);

                    //�r�[��
                    //Ray�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
                    //Ray ray = new Ray(transform.position, dirLeft);

                    ////Ray�����������I�u�W�F�N�g�̏������锠
                    //RaycastHit hit;

                    ////Ray�̔�΂��鋗��
                    //int distance = 5;

                    ////Ray�̉���    ��Ray�̌��_�@�@�@�@��Ray�̕����@�@�@�@�@�@�@�@�@��Ray�̐F
                    //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

                    ////����Ray�ɃI�u�W�F�N�g���Փ˂�����
                    ////                  ��Ray  ��Ray�����������I�u�W�F�N�g ������
                    //if (Physics.Raycast(ray, out hit, distance))
                    //{
                    //    //Ray�����������I�u�W�F�N�g��tag��Player��������
                    //    //if (hit.collider.tag == "Player")
                    //    //    Debug.Log("Ray��Player�ɓ�������");

                    //    Debug.Log("��������");


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
                    new Vector3(0, 1, 0),               // �J�n�_
                    dirRight*3f               // �I���_
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
            Debug.Log("��������");

        }

        //Debug.Log("out");
    }



}