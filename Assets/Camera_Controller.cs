using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform oyuncu; // Takip edilecek top
    private Vector3 aradakiMesafe; // Kamera ile top arasındaki fark

    void Start()
    {
        // Oyun başlarken kamera ve top arasındaki mesafeyi hafızaya al
        aradakiMesafe = transform.position - oyuncu.position;
    }

    void LateUpdate()
    {
        // Kamerayı, topun pozisyonu + aradaki mesafe kadar geriden ilerlet
        transform.position = oyuncu.position + aradakiMesafe;
    }
}