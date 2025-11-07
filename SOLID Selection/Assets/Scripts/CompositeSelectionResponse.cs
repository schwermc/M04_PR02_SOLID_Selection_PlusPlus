using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    [SerializeField] GameObject SelectionResponseHolder;

    private List<ISelectionResponse> _selectionResponses;
    private Transform _selection;
    private int _currentIndex;

    void Start()
    {
        _selectionResponses = SelectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
    }

    [ContextMenu("Next")]
    public void Next()
    {
        _selectionResponses[_currentIndex].OnDeselect(_selection);
        _currentIndex = (_currentIndex + 1) % _selectionResponses.Count;
        _selectionResponses[_currentIndex].OnSelect(_selection);
    }

    public void OnSelect(Transform selection)
    {
        _selection = selection;
        if (HasSelection())
            _selectionResponses[_currentIndex].OnSelect(selection);
    }

    public void OnDeselect(Transform selection)
    {
        _selection = selection;
        if (HasSelection())
            _selectionResponses[_currentIndex].OnDeselect(selection);
    }

    bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < _selectionResponses.Count;
    }
}
