using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 속도 변수 (Inspector에서 조절 가능)
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    
    // 입력값 저장 변수
    public float horizontalInput;
    public float forwardInput;

    void Start()
    {
        // 초기화 코드는 이 단계에서 보통 비어있습니다.
    }

    void Update()
    {
        // 키보드 입력 감지 (상하/좌우 키)
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // 전진/후진 이동 (앞뒤 키 입력 * 속도 * 시간)
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // 위 코드는 로컬 좌표 기준이며, 아래와 같이 쓰는 것이 더 일반적입니다.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // 좌우 회전 (좌우 키 입력 * 회전 속도 * 시간)
        // 차가 움직일 때만 회전하도록 구현된 단계입니다.
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}