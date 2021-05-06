using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    //메인식물
    public GameObject MainCharacter;

    //식물 위치 지정
    public GameObject Position_MainCharacterPos;


    // Start is called before the first frame update
    void Start()
    {
        //메인캐릭터(메인식물)이 정해져있는 상태라면 
        if (GameManager.Instance.MainCharacter_Plant != null)
        {
            //오브젝트 생성
            MainCharacter = Instantiate(GameManager.Instance.MainCharacter_Plant,
                Position_MainCharacterPos.transform) as GameObject;
        }
    }

}
