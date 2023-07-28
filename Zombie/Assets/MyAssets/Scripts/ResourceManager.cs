using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        // dataPath = Application.dataPath;
        // zombieDataPath = string.Format("{0}/{1}", Application.dataPath, "MyAssets/Sciptables");
        // byte[] byteZombieData = File.ReadAllBytes(zombieDataPath + "/Zombie Data Default");    

        zombieDataPath = "Scriptables";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");

        // ��Ÿ�ӿ� �����͸� �����ϴ� ���� ĳ���̶�� �Ѵ�
        // zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

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
