using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

// 좀비 게임 오브젝트를 주기적으로 생성
public class ZombieSpawner : MonoBehaviour
{
    public Zombie zombiePrefab; // 생성할 좀비 원본 프리팹

    public ZombieData[] zombieDatas; // 사용할 좀비 셋업 데이터들
    public Transform[] spawnPoints; // 좀비 AI를 소환할 위치들

    private List<Zombie> zombies = new List<Zombie>(); // 생성된 좀비들을 담는 리스트
    private int wave; // 현재 웨이브

    private void Awake()
    {
        #region 내가 만든 방법( csv의 SKIN_COLOR 값 앞에 #을 붙여야 돌아간다 )
        //zombieDatas = new ZombieData[3];
        //zombieDatas[0] = ScriptableObject.CreateInstance<ZombieData>();
        //zombieDatas[1] = ScriptableObject.CreateInstance<ZombieData>();
        //zombieDatas[2] = ScriptableObject.CreateInstance<ZombieData>();

        //float temp = 0f;

        //zombieDatas[0].name = ResourceManager.instance.zombieData_default_temp[0]["ZOMBIE_TYPE"].ToString();
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[0]["HEALTH"].ToString(), out temp);
        //Debug.LogFormat("temp => {0}", temp);
        //zombieDatas[0].health = temp;
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[0]["DAMAGE"].ToString(), out temp);
        //zombieDatas[0].damage = temp;
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[0]["SPEED"].ToString(), out temp);
        //zombieDatas[0].speed = temp;
        //ColorUtility.TryParseHtmlString(ResourceManager.instance.zombieData_default_temp[0]["SKIN_COLOR"].ToString(), out zombieDatas[0].skinColor);
        //zombieDatas[1].name = ResourceManager.instance.zombieData_default_temp[1]["ZOMBIE_TYPE"].ToString();
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[1]["HEALTH"].ToString(), out temp);
        //zombieDatas[1].health = temp;
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[1]["DAMAGE"].ToString(), out temp);
        //zombieDatas[1].damage = temp;
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[1]["SPEED"].ToString(), out temp);
        //zombieDatas[1].speed = temp;
        //ColorUtility.TryParseHtmlString(ResourceManager.instance.zombieData_default_temp[1]["SKIN_COLOR"].ToString(), out zombieDatas[1].skinColor);

        //zombieDatas[2].name =
        //    ResourceManager.instance.zombieData_default_temp[2]["ZOMBIE_TYPE"].ToString();
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[2]["HEALTH"].ToString(), out temp);
        //zombieDatas[2].health = temp;
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[2]["DAMAGE"].ToString(), out temp);
        //zombieDatas[2].damage = temp;
        //float.TryParse(ResourceManager.instance.zombieData_default_temp[2]["SPEED"].ToString(), out temp);
        //zombieDatas[2].speed = temp;
        //ColorUtility.TryParseHtmlString(ResourceManager.instance.zombieData_default_temp[2]["SKIN_COLOR"].ToString(), out zombieDatas[2].skinColor);
        #endregion // 내가 만든 방법
    }

    private void Update()
    {
        // 게임 오버 상태일때는 생성하지 않음
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            return;
        }

        // 좀비를 모두 물리친 경우 다음 스폰 실행
        if (zombies.Count <= 0)
        {
            SpawnWave();
        }

        // UI 갱신
        UpdateUI();
    }

    // 웨이브 정보를 UI로 표시
    private void UpdateUI()
    {
        // 현재 웨이브와 남은 적 수 표시
        UIManager.instance.UpdateWaveText(wave, zombies.Count);
    }

    // 현재 웨이브에 맞춰 좀비들을 생성
    private void SpawnWave()
    {
        wave += 1;

        int spawnCount = Mathf.RoundToInt(wave * 1.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            CreateZombie();
        }
    }

    // 좀비를 생성하고 생성한 좀비에게 추적할 대상을 할당
    private void CreateZombie()
    {
        //ZombieData zombieData = zombieDatas[Random.Range(0, zombieDatas.Length)];
        ZombieData2 zombieData = ResourceManager.instance.zombieDatas[Random.Range(0, ResourceManager.instance.zombieDatas.Count)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Zombie zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        zombie.Setup(zombieData);
        zombies.Add(zombie);

        // 좀비가 죽으면 아래에 등록해 놓은 메서드를 모두 실행하겠다는 의미다
        zombie.onDeath += () => zombies.Remove(zombie);
        zombie.onDeath += () => Destroy(zombie.gameObject, 10f);
        zombie.onDeath += () => GameManager.instance.AddScore(100);
    }
}