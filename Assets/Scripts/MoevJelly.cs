using UnityEngine;

public class MoveJelly : MonoBehaviour
{
    Rigidbody2D rigid;
    public float moveSpeed = 0.1f;
    Vector2 NextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }

    void FixedUpdate()
    {
        // 오브젝트의 랜덤한 방향으로 이동
        rigid.velocity = NextMove * moveSpeed;
    }

    void Think()
    {
        // 랜덤한 방향 설정
        float randomAngle = Random.Range(0, 360) * Mathf.Deg2Rad;
        NextMove = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        // 5초 후에 다시 Think 메서드를 호출
        Invoke("Think", 5);
    }
}