using UnityEngine;

public class EnemyChase4Dir : MonoBehaviour
{

    public float speed = 2f;

    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null )
            player = p.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector2 diff = player.position - transform.position;
        Vector2 moveDir = Vector2.zero;

        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            moveDir = new Vector2(Mathf.Sign(diff.x), 0f);
        }
        else
        {
            moveDir = new Vector2(0f, Mathf.Sign(diff.y));
        }

        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);
    }
}
