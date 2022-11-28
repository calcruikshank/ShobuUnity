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

    Vector3 startingPosition;
    Quaternion startingRotation;
    void Start()
    {
        GameManager.singleton.rocksInGame.Add(this);
        rb = this.GetComponent<Rigidbody2D>();
        startingPosition = this.transform.position;
        startingRotation = this.transform.rotation;
    }
    Vector2 directionToMove;
    Vector2 positionOfTouch;
    void FixedUpdate()
    {
        if (is_Touched)
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(positionOfTouch);
            directionToMove = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
            
            rb.velocity = directionToMove * speed;
        }
        if (!is_Touched)
        {
            rb.velocity *= .9f;
        }
        rb.angularVelocity *= .9f;
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

    public void ResetRock()
    {
        this.transform.position = startingPosition;
        this.transform.rotation = startingRotation;
        rb.velocity = Vector2.zero;
        is_Touched = false;
    }
}
