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
        // ������Ʈ�� ������ �������� �̵�
        rigid.velocity = NextMove * moveSpeed;
    }

    void Think()
    {
        // ������ ���� ����
        float randomAngle = Random.Range(0, 360) * Mathf.Deg2Rad;
        NextMove = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        // 5�� �Ŀ� �ٽ� Think �޼��带 ȣ��
        Invoke("Think", 5);
    }
}