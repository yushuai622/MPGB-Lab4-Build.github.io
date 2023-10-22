using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float RotationSpeed;
    public Rigidbody Asteroid_Rigi;

    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //自旋转
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime*5);
        //移动
        Asteroid_Rigi.velocity = new Vector3(0,0,-1);
        //超出地图距离销毁
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
