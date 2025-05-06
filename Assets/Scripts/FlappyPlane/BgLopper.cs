using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLopper : MonoBehaviour
{
    public int numBgCount=5;
    public int obstacleCount = 0; 
    public Vector3 obstacleLastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();    //FindObjectsOfType:이 씬에 존재하는 모든 오브젝트들을 돌아다니면서 Obstacle이 달려있는지를 찾아옴(장애물 다찾기)
        obstacleLastPosition = obstacles[0].transform.position; // 찾아온 것들 중에 가장 첫번째 transform position으로 감
        obstacleCount = obstacles.Length; //배열이니까 length

        //obstacles랜덤배치
        for(int i=0; i<obstacleCount; i++)  
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition,obstacleCount); //장애물의 배치가 끝나고 나면 배치한 위치를 받아와서 그 다음 obstacle(장애물)이 배치될 곳을 전달해줌
        }

    }
    
    //Trigger충돌을 하는 애들한테 랜덤배치를 할 수 있게 해줌
    private void OnTriggerEnter2D(Collider2D collision) //충돌체에 대한 정보만 받을 수 있음(Trigger충돌은 실제 물리 충돌X, 충돌에 대한 통보만 해줌) 그래서 매개변수가 Collider이 아니라 Collider2D임
    {
        if(collision.CompareTag("BackGround"))
        {
            float widthofBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x +=widthofBgObject *numBgCount;    //위아래바닥, 배경이 총 5개고 이 하나의 크기를 *5해서 이동시키는 과정임 
            collision.transform.position =pos;
            return;
        }

        //충돌하는 장애물만 앞으로 옮김
        Obstacle obstacle = collision.GetComponent<Obstacle>(); //충돌체에서 obstacle이 달려있는지 확인
        if(obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
    
}
