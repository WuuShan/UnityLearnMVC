using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 作为一个唯一的数据模型 一般情况 要不自己是一个单例模式对象
/// 要不自己存在一个单例模式对象中
/// </summary>
public class PlayerModel
{
    // 数据内容
    private string playerName;
    public string PlayerName => playerName;
    private int lev;
    public int Lev => lev;
    private int money;
    public int Money => money;
    private int gem;
    public int Gem => gem;
    private int power;
    public int Power => power;

    private int hp;
    public int Hp => hp;
    private int atk;
    public int Atk => atk;
    private int def;
    public int Def => def;
    private int crit;
    public int Crit => crit;
    private int miss;
    public int Miss => miss;
    private int luck;
    public int Luck => luck;

    // 通知外部更新的事件
    // 通过它和外部建立联系 而不是直接获取外部的面板
    private event UnityAction<PlayerModel> updateEvent;

    // 在外部第一次获取这个数据 如何获取
    // 通过单例模式 来达到数据的唯一性 和数据的获取
    private static PlayerModel data = null;

    public static PlayerModel Data
    {
        get
        {
            if (data == null)
            {
                data = new PlayerModel();
                data.Init();
            }
            return data;
        }
    }



    // 数据相关的操作
    // 初始化
    public void Init()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "唐老狮");
        lev = PlayerPrefs.GetInt("PlayerLev", 1);
        money = PlayerPrefs.GetInt("PlayerMoney", 999);
        gem = PlayerPrefs.GetInt("PlayerGem", 888);
        power = PlayerPrefs.GetInt("PlayerPower", 10);

        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        atk = PlayerPrefs.GetInt("PlayerAtk", 20);
        def = PlayerPrefs.GetInt("PlayerDef", 10);
        crit = PlayerPrefs.GetInt("PlayerCrit", 20);
        miss = PlayerPrefs.GetInt("PlayerMiss", 10);
        luck = PlayerPrefs.GetInt("PlayerLuck", 40);
    }
    // 更新 升级
    public void LevUp()
    {
        // 升级 改变内容
        lev += 1;

        hp += lev;
        atk += lev;
        def += lev;
        crit += lev;
        miss += lev;
        luck += lev;

        // 改变过后保存
        SaveData();
    }
    // 保存
    public void SaveData()
    {
        // 把这些数据内容 存储到本地
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerLev", lev);
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.SetInt("PlayerGem", gem);
        PlayerPrefs.SetInt("PlayerPower", power);

        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrit", crit);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLuck", luck);

        UpdateInfo();
    }

    public void AddEventListener(UnityAction<PlayerModel> function)
    {
        updateEvent += function;
    }

    public void RemoveEventListener(UnityAction<PlayerModel> function)
    {
        updateEvent -= function;
    }

    // 通知外部更新数据的方法
    private void UpdateInfo()
    {
        // 找到对应的 使用数据的脚本 去更新数据
        updateEvent?.Invoke(this);
    }
}
