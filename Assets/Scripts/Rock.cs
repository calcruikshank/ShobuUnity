using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Rock : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool is_Touched = false;
    Rigidbody2D rb;

    int pointerIDTouchingRock;
    float speed = 30f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    Vector2 directionToMove;
    Vector2 positionOfTouch;
    void Update()
    {
        if (is_Touched)
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(positionOfTouch);
            directionToMove = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
            
            rb.velocity = directionToMove * speed;
            Debug.Log(directionToMove);
        }
    }
    void FixedUpdate()
    {
        if (!is_Touched)
        {
            rb.velocity *= .8f;
        }
        rb.angularVelocity *= .8f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        is_Touched = true;
        positionOfTouch = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        is_Touched = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    bool isMoving = false;
    public void OnDrag(PointerEventData eventData)
    {
        
        if (is_Touched)
        {
            positionOfTouch = eventData.position;
        }
    }
}
