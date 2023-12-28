using UnityEngine;

public class JellyClick : MonoBehaviour
{
    public int jelatinValue = 1;
    private Animator animator;
    private bool isTouched = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        isTouched = true;

        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.AddJelatin(jelatinValue);
        }
    }

    void Update()
    {
        if (isTouched)
        {
            isTouched = false;
        }
    }
}