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
    public ZombieData zombieData_default = default;

    private static string zombieDataCSVPath = default;
    public List<Dictionary<string, object>> zombieData_default_temp = default;

    public List<ZombieData2> zombieDatas = default;

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

        zombieDatas = new List<ZombieData2>();

        TextAsset csvZData = Resources.Load<TextAsset>(zombieDataCSVPath);

        string[] zDatas_Str = csvZData.text.Split('\n');
        ZombieData2 loadZData = default;
        for (int i = 1; i < zDatas_Str.Length; i++)
        {
            loadZData = new ZombieData2(zDatas_Str[i]);
            zombieDatas.Add(loadZData);
        }

        // 암호화 AES-256 
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
