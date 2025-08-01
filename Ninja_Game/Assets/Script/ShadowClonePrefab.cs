using UnityEngine;

public class ShadowClonePrefab : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damge = 25f;
    [SerializeField] private float maxlifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,maxlifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Character>();
            if (enemy != null)
            {
                enemy.OnHit(damge);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("EnemyAttack")) ;
        {
           Destroy(gameObject);
        }
    }
}
