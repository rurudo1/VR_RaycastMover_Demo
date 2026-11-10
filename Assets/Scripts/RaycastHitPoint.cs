using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitPoint : MonoBehaviour
{
    private Move move;

    private void Start()
    {
        move = GameObject.Find("Ball").GetComponent<Move>();
    }
    public Vector3 GetDestination()
    {
        RaycastHit hit; //声明一个RayCastHit
        Physics.Raycast(transform.position, transform.forward, out hit); //从本物体的位置向前射出一条射线，碰撞信息存储到hit里，没有out就无法存储
        return hit.point;
    }

    public void SetDestination()
    {
        move.MoveAgent(GetDestination()); //通过GetDestination得到碰撞点的位置，传给Move.MoveAgent进行移动。
    }
}
