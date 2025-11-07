﻿using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selection;
    private ISelectionResponse _selectionResponse;

    private Transform _currentselection;

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selection = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        if (_currentselection != null)
            _selectionResponse.OnDeselect(_currentselection);

        _selection.Check(_rayProvider.CreateRay());
        _currentselection = _selection.GetSelection();

        if (_currentselection != null)
            _selectionResponse.OnSelect(_currentselection);
    }
}