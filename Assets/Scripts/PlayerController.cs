using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float PlayerSpeed;
    private CharacterController player;//创建角色控制器
    public GameObject planeObj;
    private Vector3 planeSize;
    private Vector3 playerSize;
    private Quaternion start_rotation;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        //获取地板尺寸
        planeSize = planeObj.GetComponent<MeshRenderer>().bounds.size;
        //获取玩家尺寸
        playerSize = player.GetComponent<MeshRenderer>().bounds.size;
        //Debug.Log(playerSize);
        //start_rotation = player.transform.rotation;//记录玩家初始旋转角度

        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // 以直接设置坐标的方式进行移动
        float horizontal = Input.GetAxis("Horizontal");//获取水平轴
        float vertical = Input.GetAxis("Vertical");//获取垂直轴
        Vector3 dir = new Vector3(horizontal, 0, vertical) * PlayerSpeed * Time.fixedDeltaTime;//创建成一个方向向量
        player.Move(dir);//更复杂的移动，不计算重力影响
        //player.SimpleMove(dir);//以一定速度来移动，移动时自动计算重力因素影响

        if (planeSize.x / 2 < Mathf.Abs(player.transform.position.x) + 0.56 || planeSize.z / 2 < Mathf.Abs(player.transform.position.z) + 0.845)
        {
            //限制物体可移动的范围 
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -planeSize.x / 2 + (float)0.56, planeSize.x / 2 - (float)0.56), (float)0.3, Mathf.Clamp(player.transform.position.z, -planeSize.z / 2 + (float)0.845, planeSize.z / 2 - (float)0.845));
        }

        //int rotateSpeed=200;
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, -25);
            //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation,
            //Quaternion.Euler(0, 0, -25), rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 25);
            //            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation,
            //Quaternion.Euler(0, 0, 25), rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, start_rotation, rotateSpeed * Time.deltaTime);
        }
    }


    //void OnMove(InputValue value)
    //{
    //    moveValue = value.Get<Vector2>();
    //}

    void FixedUpdate()
    {
        //    //使用刚体施加力的方式进行移动，更接近物理世界
        //    Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        //    GetComponent<Rigidbody>().AddForce(movement * PlayerSpeed * Time.fixedDeltaTime);
        //    Debug.Log(player.transform.rotation);
    }
    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
    //void OnTriggerEnter()
    //{
    //    Destroy(gameObject);
    //}
}
