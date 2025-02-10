using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость движения
    public float jumpForce = 10f; // Сила прыжка
    private Rigidbody2D rb;  // Ссылка на Rigidbody2D

    public Transform groundCheck;  // Позиция для проверки земли (не используется, но оставляем)
    public LayerMask groundLayer;  // Слой земли (не используется)

    private bool isFacingRight = true; // Для поворота персонажа

    // Для перезарядки прыжка
    private float jumpCooldown = 1f;  // Время перезарядки прыжка
    private float timeSinceLastJump = 0f;  // Время, прошедшее с последнего прыжка

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Получаем компонент Rigidbody2D
    }

    void Update()
    {
        // Движение по оси X
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);  // Двигаем персонажа по оси X, но сохраняем вертикальную скорость

        // Поворот персонажа в зависимости от направления движения
        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }

        // Обновляем время с последнего прыжка
        timeSinceLastJump += Time.deltaTime;

        // Прыжок с перезарядкой
        if (Input.GetButtonDown("Jump") && timeSinceLastJump >= jumpCooldown)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            timeSinceLastJump = 0f;  // Сбрасываем таймер после прыжка
        }
    }

    // Функция для поворота персонажа
    void Flip()
    {
        isFacingRight = !isFacingRight;  // Меняем направление
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  // Меняем знак по оси X для поворота
        transform.localScale = localScale;
    }
}
