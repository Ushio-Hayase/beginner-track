using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // 플레이어(자동차) 오브젝트를 Inspector에서 연결해야 함
    public GameObject player;
    
    // 카메라와 플레이어 사이의 거리 (오프셋)
    // 씬 뷰에서 카메라 위치를 잡은 뒤 값을 수정하세요. 보통 (0, 5, -7) 정도를 사용합니다.
    private Vector3 offset = new Vector3(0, 5, -7);

    void Start()
    {
        
    }

    // 카메라 움직임은 Update보다 LateUpdate에서 처리하는 것이 부드럽습니다.
    void LateUpdate()
    {
        // 카메라 위치를 플레이어 위치 + 오프셋으로 매 프레임 갱신
        transform.position = player.transform.position + offset;
    }
}