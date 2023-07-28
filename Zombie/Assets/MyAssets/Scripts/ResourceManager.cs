using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
//using UnityEditor; ※ Build 안됨

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager m_instance;

    public static ResourceManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 ResourceManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    // private string dataPath = default;
    private static string zombieDataPath = default;
    private static string zombieDataCSVPath = default;
    public ZombieData zombieData_default = default;
    [SerializeField]
    public List<Dictionary<string, object>> zombieData_default_temp = default;

    private void Awake()
    {
        // dataPath = Application.dataPath;
        // zombieDataPath = string.Format("{0}/{1}", Application.dataPath, "MyAssets/Sciptables");
        // byte[] byteZombieData = File.ReadAllBytes(zombieDataPath + "/Zombie Data Default");    

        zombieDataPath = "Scriptables";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");

        zombieDataCSVPath = "ZombieDatas";
        zombieDataCSVPath = string.Format("{0}/{1}", zombieDataCSVPath, "ZombieSurvival Datas - ZombieDatas");

        // 런타임에 데이터를 저장하는 것을 캐싱이라고 한다
        // zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);
        zombieData_default_temp = CSVReader.Read(zombieDataCSVPath);

        //Debug.LogFormat("{0}", zombieData_default_temp[0]["HEALTH"]);
        //int loopCnt = 0;
        //foreach (var csvDict in zombieData_default_temp)
        //{
        //    foreach (var key_ in csvDict.Keys)
        //    {
        //        Debug.LogFormat("리스트 인덱스: {2}, 키: {0}, 값: {1}",
        //            key_, csvDict[key_], loopCnt);
        //    }
        //    loopCnt++;
        //}

        //Debug.LogFormat("Zombie Data Path: {0}", zombieDataPath);
        //Debug.LogFormat("Zombie Data: {0}, {1}, {2}", zombieData_default.health, zombieData_default.damage, zombieData_default.speed);
        Debug.LogFormat("게임의 Save Data를 저장하는 경로: {0}", Application.persistentDataPath);

        // 암호화 AES-256 
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
