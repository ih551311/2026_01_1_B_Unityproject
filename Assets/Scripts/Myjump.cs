using UnityEngine;
using UnityEngine.UI;

public class Myjump : MonoBehaviour
{
    public Rigidbody rigidbody;  //강체  (형태의 크기가 고정된 고체) 물리 현상이 동작하게 해주는 컨포넌트
    public float power = 200f; // 변수 힘을 선언 함
    public float timer = 0;
    public Text TextUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TextUI.text = timer.ToString();

        if (Input.GetKeyDown(KeyCode.Space)) //스페이스 키를 눌렀을떄
        {
            power += Random.Range(-100, 200);
            rigidbody.AddForce(transform.up * power); // 변수 (power)의 위쪽으로 힘을 준다
        }

        if(this.gameObject.transform.position.y>5 || this.gameObject.transform.position.y < -3)
        {
            //이 오브젝트의 y좌표점 위치가 5보다 크거나 -3보다 작을 경우
            Destroy(this.gameObject);
        }
    }
}
