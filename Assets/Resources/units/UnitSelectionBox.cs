using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    Camera myCam;
 
    [SerializeField]
    RectTransform boxVisual;
 
    Rect selectionBox;
 
    Vector2 startPosition;
    Vector2 endPosition;
 
    private void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }
 
    private void Update()
    {
        // Sur Click
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
 
            // Pour la sélection des unités
            selectionBox = new Rect();
        }
 
        // Sur Dragage de la box
        if (Input.GetMouseButton(0))
        {
            if (boxVisual.rect.width > 0 || boxVisual.rect.height > 0)
            {
                UnitSelectionManager.Instance.DeselectAll();
                SelectUnits(); 
            }
            
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
 
        // Sur relevé de click
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
 
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
    }
 
    void DrawVisual()
    {
        // Calcule la position de départ et de fin de la boîte de sélection
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;
 
        // Calcule le centre de la boîte de selection
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
 
        // Place box de sélection visuelle à partir de son centre
        boxVisual.position = boxCenter;
 
        // Calcule la taille de la selection box en hauteur et longeur
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
 
        // Détermine la taille de la selection box visuelle à partir de sa taille calculée
        boxVisual.sizeDelta = boxSize;
    }
 
    void DrawSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
 
 
        if (Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }
 
    void SelectUnits()
    {
        foreach (var unit in UnitSelectionManager.Instance.allUnitsList)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitSelectionManager.Instance.DragSelect(unit);
            }
        }
    }
}
