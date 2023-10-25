﻿using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    private Queue<Command> _commands = new Queue<Command>();
    private Command _currentCommand;

    private SpriteRenderer _spriteRenderer;

    Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        ListenForCommands();
        ProcessCommands();
    }

    private void ProcessCommands()
    {
        if (_currentCommand != null && !_currentCommand.IsFinished)
            return;

        if (_commands.Count == 0)
            return;

        _currentCommand = _commands.Dequeue();
        _currentCommand.Execute();
        Debug.Log("Executing command");
    }

    private void ListenForCommands()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Adding move command");
            Vector3 point = _camera.ScreenToWorldPoint(
                new Vector3(UnityEngine.Random.Range(200, Screen.width - 200),
                UnityEngine.Random.Range(200, Screen.height - 200),
                _camera.nearClipPlane));
            var moveCommand = new MoveCommand(point, UnityEngine.Random.Range(4f, 8f), transform, _spriteRenderer);
            _commands.Enqueue(moveCommand);

        }
    }
}
