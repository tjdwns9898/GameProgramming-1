﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null; //싱글톤

    public GameObject MainCharacter_Plant; //중앙에 서있을 식물 이미지 이름


    //저장 데이터 형식
    [System.Serializable]
    public class Data
    {
        public int Money;
    }

    public Data data;


    /// //////////////////////////////////////////////////////////////////////////////////
    /// 싱글톤 생성
    /// 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //씬 전환이 되어도 파괴되지 않는다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //씬 전환이후 그 씬에도 gamemanager가 있을수 있음.
            //따라서 새로운 씬의 gamemanager 파괴
            Destroy(this.gameObject);

        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    /// //////////////////////////////////////////////////////////////////////////////////

    public void GameSave()
    {
        string jsonData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data>(jsonData);
    }
}
