using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick_Button : MonoBehaviour
{

    public GameObject BackBtn;
    public GameObject Menu;
    public GameObject MenuPanel;
    public GameObject ExitBtn;
    public GameObject SoundBtn;
    public GameObject SettingBtn;
    public GameObject Seed;
    public GameObject SeedPanel;
    public GameObject Seed1;
    public GameObject Seed2;
    public GameObject Seed3;
    public GameObject Water;
    public GameObject Nuturition;
    public GameObject BugCatch;
    public GameObject Harvest;

    public void BackBtn_clicked()
    {
        Debug.Log("전체화면으로 돌아가기");
    }

    public void Menu_clicked()
    {
        MenuPanel.SetActive(true);
        SeedPanel.SetActive(false);
    }

    public void Exit_clicked()
    {
        Debug.Log("게임종료");
    }

    public void SoundBtn_clicked()
    {
        Debug.Log("소리 ON/OFF");
    }

    public void SettingBtn_clicked()
    {
        Debug.Log("설정");
    }

    public void Seed_clicked()
    {
        SeedPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void Seed1_clicked()
    {
        Debug.Log("씨앗1");
    }

    public void Seed2_clicked()
    {
        Debug.Log("씨앗2");
    }

    public void Seed3_clicked()
    {
        Debug.Log("씨앗3");
    }

    public void Water_clicked()
    {
        Debug.Log("물주기");
    }

    public void Nuturition_clicked()
    {
        Debug.Log("거름주기");
    }

    public void BugCatch_clicked()
    {
        Debug.Log("벌레잡기");
    }

    public void Harvest_clicked()
    {
        Debug.Log("수확하기");
    }

}