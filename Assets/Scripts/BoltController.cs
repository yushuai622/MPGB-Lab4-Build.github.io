using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    public Rigidbody Bolt_Rigi;
    public float BoltSpeed;
    public GameObject playerObj;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //实例化预制件
            Rigidbody p = Instantiate(Bolt_Rigi, playerObj.transform.position+new Vector3(0,0,1.5f), Quaternion.Euler(90, 0, 0));
            p.velocity = transform.forward * BoltSpeed;
        }

    }
}
