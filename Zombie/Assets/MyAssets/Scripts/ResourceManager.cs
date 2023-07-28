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

        // ��Ÿ�ӿ� �����͸� �����ϴ� ���� ĳ���̶�� �Ѵ�
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

        // ��ȣȭ AES-256 
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
