using System.Collections.Generic;
using UnityEngine;

// 좀비 생성시 사용할 셋업 데이터
[CreateAssetMenu(menuName = "Scriptable/ZombieData", fileName = "Zombie Data")]
public class ZombieData : ScriptableObject
{
    public float health = 100f; // 체력
    public float damage = 20f; // 공격력
    public float speed = 2f; // 이동 속도
    public Color skinColor = Color.red; // 피부색
}

enum ZombieLoadIndex
{
    ZOMBIE_HEALTH = 1,
    ZOMBIE_DAMAGE,
    ZOMBIE_SPEED,
    ZOMBIE_COLOR
};

public class ZombieData2
{
    public float health = 100f; // 체력
    public float damage = 20f; // 공격력
    public float speed = 2f; // 이동 속도
    public Color skinColor = Color.red; // 피부색

    public ZombieData2(string zombieDataStr)
    {
        string[] zDatas_Str = zombieDataStr.Split(',');

        // { ZombieData 초기화
        float.TryParse(zDatas_Str[(int)ZombieLoadIndex.ZOMBIE_HEALTH], out health);
        float.TryParse(zDatas_Str[(int)ZombieLoadIndex.ZOMBIE_DAMAGE], out damage);
        float.TryParse(zDatas_Str[(int)ZombieLoadIndex.ZOMBIE_SPEED], out speed);

        // { colorHtmlCode 를 불러왔을 떄 쓰레기값을 제거
        string colorHtmlCode = zDatas_Str[(int)ZombieLoadIndex.ZOMBIE_COLOR];
        colorHtmlCode = colorHtmlCode.Substring(0, 6);
        colorHtmlCode = string.Format("#{0}FF", colorHtmlCode);
        // } colorHtmlCode 를 불러왔을 떄 쓰레기값을 제거

        ColorUtility.TryParseHtmlString(colorHtmlCode, out skinColor);
        // } ZombieData 초기화

        // { 예외처리
        bool isValid = Mathf.Approximately(health, 0f) ||
            (Mathf.Approximately(damage, 0f) && Mathf.Approximately(speed, 0f));

        if (isValid == true)
        {
            Debug.LogErrorFormat("[ZombieData2] Can't initialize ZombieData");
            Debug.Assert(isValid);
        }
        // } 예외처리
    }       // ZombieData2()
}