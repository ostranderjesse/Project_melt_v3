using UnityEngine;

internal interface ISelectionResponse
{
    void SelectObject(Transform selection);

    void DeslectObject(Transform selection);
}