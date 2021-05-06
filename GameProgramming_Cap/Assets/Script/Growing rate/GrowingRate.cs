using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingRate : MonoBehaviour
{
    //현재시간 지정
    int nowDate;

    //식물 시간
    int Plant_time;

    //식물 달 , 일 , 시간, 분 , 초
    int Plant_MM;
    int Plant_dd;
    int Plant_HH;
    int Plant_mm;
    int Plant_ss;

    public int GrowingRate_Percent; // 성장도

    // Start is called before the first frame update
    void Start()
    {
        //식물 시간을 가져온다.
        Plant_time = int.Parse(GameManager.Instance.Plant_time);

        Plant_MM = Plant_time / 100000000;
        Plant_dd = Plant_time % 100000000 / 1000000;
        Plant_HH = Plant_time % 1000000 / 10000;
        Plant_mm = Plant_time % 10000 / 100;
        Plant_ss = Plant_time % 100;
    }

    // Update is called once per frame
    void Update()
    {
        GrowingRatePercent();
    }

    void GrowingRatePercent()
    {
        //현재 시간
        nowDate = int.Parse(System.DateTime.Now.ToString("MMddHHmmss"));

        //현재 시간 나누기
        int MM = nowDate / 100000000;
        int dd = nowDate % 100000000 / 1000000;
        int HH = nowDate % 1000000 / 10000;
        int mm = nowDate % 10000 / 100;
        int ss = nowDate % 100;

        //달 나누기 할때 사용할 변수
        int k = 1;

        GrowingRate_Percent =
        compareTwoInt(ref mm, ss, Plant_ss, 60) +
        (compareTwoInt(ref HH, mm, Plant_mm, 60) * 60) +
        (compareTwoInt(ref dd, HH, Plant_HH, 24) * 60 * 60) +
        (compareTwoInt(ref MM, dd, Plant_dd, 60) * 60 * 60 * 24) +
        (compareTwoInt(ref k, MM, Plant_MM, 30) * 60 * 60 * 24 * 60);

        print(GrowingRate_Percent);
    }

    int compareTwoInt(ref int mother, int k1, int k2, int num)
    {
        if(k1 >= k2)
        {
            return k1 - k2;
        }

        else
        {
            mother--;
            return (k1 + num);
        }
    }

}
