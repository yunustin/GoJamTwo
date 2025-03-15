using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float tileSize = 1f; // Distance per tile
    public float moveSpeed = 10f; // Movement smoothness
    public float rotationSpeed = 300f; // Rotation speed (degrees per second)
    public int gridWidth = 3; // Grid width (columns)
    public int gridHeight = 5; // Grid height (rows)

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private bool isRotating = false; // Prevents movement while turning

    // For displaying tile position in the Inspector
    public Vector2Int currentTilePosition;

    void Start()
    {
        targetPosition = transform.position;
        targetRotation = transform.rotation;

        currentTilePosition = GetTilePosition(transform.position);
    }

    void Update()
    {
        HandleInput();
        SmoothMove();
        SmoothRotate();

        currentTilePosition = GetTilePosition(transform.position);
    }

    //MOVEMENTSCRIPTS

    void HandleInput()
    {
        if (!isRotating) // Block movement if rotating
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveForward();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                MoveBackward();
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            RotateRight();
        }
    }

    public void MoveForward()
    {
        Vector3 nextPos = targetPosition + transform.forward * tileSize;
        if (IsInsideGrid(nextPos))
        {
            targetPosition = nextPos;
        }
    }

    void MoveBackward()
    {
        Vector3 nextPos = targetPosition - transform.forward * tileSize;
        if (IsInsideGrid(nextPos))
        {
            targetPosition = nextPos;
        }
    }

    void RotateLeft()
    {
        targetRotation *= Quaternion.Euler(0, -90, 0);
        isRotating = true;
    }

    void RotateRight()
    {
        targetRotation *= Quaternion.Euler(0, 90, 0);
        isRotating = true;
    }

    void SmoothMove()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    void SmoothRotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            isRotating = false; // Unlock movement once rotation is finished
        }
    }

    bool IsInsideGrid(Vector3 newPos)
    {
        int newX = Mathf.RoundToInt(newPos.x / tileSize);
        int newY = Mathf.RoundToInt(newPos.z / tileSize);
        return (newX >= 0 && newX < gridWidth) && (newY >= 0 && newY < gridHeight);
    }

    // Method to calculate the current tile position based on the world position
    Vector2Int GetTilePosition(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x / tileSize);
        int y = Mathf.RoundToInt(worldPosition.z / tileSize);
        return new Vector2Int(x, y);
    }
}