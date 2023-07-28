using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
//using UnityEditor; �� Build �ȵ�

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager m_instance;

    public static ResourceManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ ResourceManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
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

        // ��Ÿ�ӿ� �����͸� �����ϴ� ���� ĳ���̶�� �Ѵ�
        // zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);
        zombieData_default_temp = CSVReader.Read(zombieDataCSVPath);

        //Debug.LogFormat("{0}", zombieData_default_temp[0]["HEALTH"]);
        //int loopCnt = 0;
        //foreach (var csvDict in zombieData_default_temp)
        //{
        //    foreach (var key_ in csvDict.Keys)
        //    {
        //        Debug.LogFormat("����Ʈ �ε���: {2}, Ű: {0}, ��: {1}",
        //            key_, csvDict[key_], loopCnt);
        //    }
        //    loopCnt++;
        //}

        //Debug.LogFormat("Zombie Data Path: {0}", zombieDataPath);
        //Debug.LogFormat("Zombie Data: {0}, {1}, {2}", zombieData_default.health, zombieData_default.damage, zombieData_default.speed);
        Debug.LogFormat("������ Save Data�� �����ϴ� ���: {0}", Application.persistentDataPath);

        // ��ȣȭ AES-256 
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
