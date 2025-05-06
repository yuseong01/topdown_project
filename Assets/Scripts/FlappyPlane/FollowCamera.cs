using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; //player
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
            return;

        offsetX = transform.position.x - target.position.x; //처음에 배치했을때 카메라하고 플레이어 사이의 거리가 저장됨. 그 거리를 유지하면서 이동을 할것이다


    }

    // Update is called once per frame
    void Update()
    {
        if(target==null)
            return;

        Vector3 pos = transform.position;   //내위치 가져오기, position에서 x값자체가 바로 변경 가능한 값이 아니기때문에 밑에처럼 pos.x이렇게 해서 값을 변경한 후에 다시 넣어줘야함
        pos.x = target.position.x + offsetX; //캐릭터 위치로 카메라가 따라가는데 캐릭터 위치보다 offset, 즉 처음에 배치놓은 거리만큼 떨어진 상태로 계속 따라감
        transform.position = pos;

    }
}
