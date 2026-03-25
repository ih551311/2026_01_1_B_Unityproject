using System.Runtime.CompilerServices;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float moveSpeed = 8f;     // 이동 속도 변수 설정
    public float jumpForce = 5f;
    public Rigidbody rb;  //플레이어 강체 선언

    public bool isGrounded  = true;
    public int coinCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //속도 값으로 직접 이동
        rb. linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

        //점프입력
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
            {
                coinCount++;
                Destroy(collision.gameObject);
            }
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

        private void OnTriggerEnter (Collider other)
        {
            if (other.CompareTag("coin"))
            {
                coinCount++;
                Destroy(other.gameObject);
            }

        }
    }

