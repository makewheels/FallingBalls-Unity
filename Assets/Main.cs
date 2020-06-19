using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject baseObject;
    private float rotateSpeed = 20;
    private float force = 200;


    // Start is called before the first frame update
    void Start()
    {
        //初始化基准位置
        baseObject.transform.position = new Vector3(0, 18, 0);

    }

    // Update is called once per frame
    private float countTime = 0;
    //小球集合
    private List<GameObject> ballList = new List<GameObject>();
    void Update()
    {
        //时间间隔
        countTime += Time.deltaTime;
        if (countTime < 0.35) {
            return;
        }
        //重置计时
        countTime = 0;

        //开始执行创建小球了
        //旋转base
        baseObject.transform.Rotate(0, rotateSpeed, 0);
        //创建小球
        GameObject ball = GameObject.Instantiate(ballPrefab);
        //加入集合
        ballList.Add(ball);
        //删除过多的小球
        Debug.Log(ballList.Count);
        while (ballList.Count > 100)
        {
            GameObject.Destroy(ballList[0]);
            ballList.RemoveAt(0);
        }
        //设置颜色
        Color color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        ball.GetComponent<MeshRenderer>().material.color = color;
        //设置位置
        ball.transform.position = baseObject.transform.position;
        //施力
        ball.GetComponent<Rigidbody>().AddForce(baseObject.transform.rotation * Vector3.one * force);
    }
}
