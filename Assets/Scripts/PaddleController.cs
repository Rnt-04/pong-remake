using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public bool isRightPaddle;

    void Update()
    {
        float movement = Input.GetAxis(isRightPaddle ? "Vertical" : "Vertical2") * speed * Time.deltaTime;
        transform.Translate(0, movement, 0);

        // Restrict movement within the screen
        float clampedY = Mathf.Clamp(transform.position.y, -3.5f, 3.5f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
