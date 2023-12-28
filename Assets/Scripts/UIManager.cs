using UnityEngine;
using UnityEngine.UI; // Text를 사용하기 위해 필요합니다.

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text jelatinText;
    public Text goldText;

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

    void Start()
    {
        if (CurrencyManager.Instance != null)
        {
            UpdateJelatinUI();
            UpdateGoldUI();
        }
    }

    public void UpdateJelatinUI()
    {
        if (jelatinText != null)
            jelatinText.text = CurrencyManager.Instance.Jelatin.ToString();
    }

    public void UpdateGoldUI()
    {
        if (goldText != null)
            goldText.text = CurrencyManager.Instance.Gold.ToString();
    }
}
