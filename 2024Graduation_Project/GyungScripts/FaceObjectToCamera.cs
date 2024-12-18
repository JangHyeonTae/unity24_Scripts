using UnityEngine;

public class FaceObjectToCamera : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            Debug.LogWarning("Camera.main이 null입니다. MainCamera 태그가 있는 카메라가 있는지 확인하세요.");
        }
    }
}
