using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //obstacle이 상하로 이동할때 얼마나 이동할거냐
    public float highPosY = 1f; 
    public float lowPosY = -1f;

    //Top과 Bottom사이를 얼마나 가져갈거냐
    public float holeSizeMin = 1f;  
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    //오브젝트들을 배치할때 폭을 얼마나 가져갈건지
    public float widthPadding = 4f; 

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize); //holeSize의 반만큼을 위로 올림
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding,0); //마지막에 배치된 오브젝트 뒤에 배치
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player)
            gameManager.AddScore(1);
    }

}
