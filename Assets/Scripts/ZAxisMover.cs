using UnityEngine;

public class Za : MonoBehaviour
{

    public float speed = 5.0f;
    public float timer = 5.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //z축 방향으로 앞으로 이동
        transform.Translate(0, 0, speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
