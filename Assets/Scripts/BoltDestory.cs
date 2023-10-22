using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //超出地图距离后销毁
        if (transform.position.magnitude > 10)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
