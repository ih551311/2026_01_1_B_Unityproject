using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("기본 이동 설정")]
    public float moveSpeed = 8f;     // 이동 속도 변수 설정
    public float jumpForce = 5f;
    public float turnSpeed = 10f;
    public Rigidbody rb;  //플레이어 강체 선언

    [Header("점프 개선 설정")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    [Header("지면 감지 설정")]
    public float coyoteTime = 0.15f;
    public float coyoteTimeCounter;
    public bool realGround = true;

    [Header("글라이더 설정")]
    public GameObject gliderObject;
    public float gliderFallSpeed = 1.0f;
    public float gliderMoveSpeed = 7.0f;
    public float GliderMaxTime = 5.0f;
    public bool IsGliding = false;

    public bool isGrounded  = true;
    public int coinCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coyoteTimeCounter = 0;

        if (gliderObject != null)
        {
            gliderObject.SetActive(false);
        }

        gliderTimeLeft = GliderMaxTime;
    }

    void Update()
    { 
            UpdateGrounededState;
        }

    // Update is called once per frame
    void Update()
    {
        //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp( transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        //속도 값으로 직접 이동
        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

        //착시 점프 높이 구현
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && ! Input.GetButton("Jump"))
            {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

        //점프입력
        if (Input.GetButtonDown("Jump") && isGrounded)
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
    
//지면 상태 업데이트 함수 
void UpdateGrounedState()
{
    if (realGround)
    {
        coyoteTimeCounter = coyoteTime;
        isGround = true;
    }
    else
    {
        if (coyoteTimeCounter -= Time.deltaTime;
        isGround = true;)
    }
    GraphElementScopeExtensions{
            isGroundd = false;
        }
]

        void EnableGlider()
        {
            IsGliding = true;
            if (gliderObject != null)
            {
                gliderObject.SetActive(true);
            }
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -gliderFallSpeed, rb.linearVelocity.z);
        }

