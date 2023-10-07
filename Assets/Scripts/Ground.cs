using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    float triggerWidth;
    float triggerHeight;
    [SerializeField] bool noTrigger = false;
    [SerializeField] BoxCollider2D triggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        if(noTrigger)
        {
            Destroy(triggerCollider);
        }
        else
        {
            triggerWidth = spriteRenderer.size.x;
            triggerHeight = spriteRenderer.size.y;

            triggerCollider.size = new Vector2(triggerWidth - 1f, triggerHeight);
            triggerCollider.offset = new Vector2(0, 0.1f);
        }
    }
}
