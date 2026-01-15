
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove2D : MonoBehaviour
{
    public float speed = 0.01f;

    public SpriteRenderer sr;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    Vector2 move;

    void Update()
    {
        move = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            move.y = 1;
            sr.sprite = upSprite;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move.y = -1;
            sr.sprite = downSprite;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            move.x = -1;
            sr.sprite = leftSprite;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            move.x = 1;
            sr.sprite = rightSprite;
        }

        transform.Translate(move * speed * Time.deltaTime);
    }
}