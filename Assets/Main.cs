using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject baseObject;
    private float rotateSpeed = 20;
    private float force = 150;


    // Start is called before the first frame update
    void Start()
    {
        //初始化基准位置
        baseObject.transform.position = new Vector3(0, 18, 0);

    }

    // Update is called once per frame
    private float countTime = 0;
    void Update()
    {
        //间隔时间执行一次
        countTime += Time.deltaTime;
        if (countTime < 0.4) {
            return;
        }
        //重置计时
        countTime = 0;
        //旋转
        baseObject.transform.Rotate(0, rotateSpeed, 0);
        //创建小球
        GameObject ball = GameObject.Instantiate(ballPrefab);
        //设置小球位置
        ball.transform.position = baseObject.transform.position;
        //施力
        ball.GetComponent<Rigidbody>().AddForce(baseObject.transform.rotation * Vector3.one * force);
    }
}
