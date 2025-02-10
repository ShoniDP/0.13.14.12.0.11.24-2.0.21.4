using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Ссылка на игрока
    public float smoothSpeed = 0.125f; // Скорость следования камеры

    private float targetY;  // Целевая высота камеры

    void Start()
    {
        // Изначальная высота камеры (например, она начинается на Y = 0)
        targetY = transform.position.y;
    }

    void Update()
    {
        // Если игрок пересекает высоту Y = 5, поднимаем камеру до Y = 10
        if (player.position.y > 5f && targetY == transform.position.y)
        {
            targetY = 10f;
        }

        // Если игрок пересекает высоту Y = 15, поднимаем камеру до Y = 20
        if (player.position.y > 15f && targetY == 10f)
        {
            targetY = 20f;
        }

        // Новая позиция камеры с фиксированным X и Z, только изменяем Y
        Vector3 desiredPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        // Плавное движение камеры по Y
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
