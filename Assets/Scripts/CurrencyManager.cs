using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    private int jelatin = 200;
    private int gold = 200;

    public int Jelatin
    {
        get { return jelatin; }
        set
        {
            jelatin = value;
            UIManager.Instance.UpdateJelatinUI();
        }
    }

    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            UIManager.Instance.UpdateGoldUI();
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Jelatin�� �߰��ϴ� �޼���
    public void AddJelatin(int amount)
    {
        Jelatin += amount;
    }

    // Gold�� �߰��ϴ� �޼���
    public void AddGold(int amount)
    {
        Gold += amount;
    }
}
