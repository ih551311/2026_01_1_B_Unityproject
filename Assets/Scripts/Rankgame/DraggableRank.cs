using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class DraggableRank : MonoBehaviour
{

    public int rankLevel = 1;
    public float dragSpeed = 30f;
    public float snapBackSprrd = 20f;

    public bool isRragging = false;
    public Camera mainCameras;
    public GridCell surrentCell;

    public Camera mainCamera;
    public Vector3 originalPosition;
    public GridCell currentCell;

    public RankGameManager sprieRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveToCell(GridCell targetCell);
    {
    if (currentCell ! = null )
    }
}
