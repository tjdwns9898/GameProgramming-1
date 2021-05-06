using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    //벌레가 갈 위치(도착지)
    public GameObject Bug_Destination;
    //시작위치
    Vector3 objectStartPos = Vector3.zero;

    //도착까지 걸릴 시간
    public float Bug_ArriveTime;
    //도착지까지 사용될 카운트 시간
    float count = 0;




    // Start is called before the first frame update
    void Start()
    {
        //시작위치 지정
        objectStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //아직 도착을 못했다면
        if (count <= Bug_ArriveTime)
        {
            count += Time.deltaTime;

            //해당장소 이동
            gameObject.transform.position = Vector3.Lerp(objectStartPos,
                Bug_Destination.transform.position,
                count / Bug_ArriveTime);

            //해당 방향으로 처다보기
            Vector3 dir = Bug_Destination.transform.position - objectStartPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         }
    }
}
