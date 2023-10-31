using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class UnitBehaviour : MonoBehaviour
{
    public Action<Transform> OnUnitMove;
    private Queue<Command> _commands = new Queue<Command>();
    private Command _currentCommand;

    private SpriteRenderer _spriteRenderer;


    Camera _camera;

    private float _randomNumber;
    private CommandType _commandType;


    private void Start()
    {
        _camera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Vector3 screenPos = _camera.WorldToScreenPoint(new Vector3(0.4f, -2.45f, 0));
        Debug.Log(screenPos);
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
                UnityEngine.Random.Range(140, 425),
                _camera.nearClipPlane));
            var moveCommand = new MoveCommand(point, UnityEngine.Random.Range(8f, 12f), transform, _spriteRenderer);
            _commands.Enqueue(moveCommand);

        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            var standingCommand = new StandingCommand(UnityEngine.Random.Range(2f, 5f));
            _commands.Enqueue(standingCommand);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            var flipperCommand = new FlipperCommand(_spriteRenderer, UnityEngine.Random.Range(2f, 4f));
            _commands.Enqueue(flipperCommand);
        }

        //StartCoroutine(UnitCommandProvider());

    }

    private IEnumerator UnitCommandProvider()
    {
        yield return new WaitForSeconds(2f);

        if (_commands.Count > 6)
            yield return null;

        _randomNumber = UnityEngine.Random.Range(0, 3);

        switch (_randomNumber)
        {
            case 0:
                var standingCommand = new StandingCommand(UnityEngine.Random.Range(2f, 5f));
                _commands.Enqueue(standingCommand);
                break;
            case 1:
                var flipperCommand = new FlipperCommand(_spriteRenderer, UnityEngine.Random.Range(2f, 4f));
                _commands.Enqueue(flipperCommand);
                break;
            case 2:
                Vector3 point = _camera.ScreenToWorldPoint(
                new Vector3(UnityEngine.Random.Range(200, Screen.width - 200),
                UnityEngine.Random.Range(140, 425),
                _camera.nearClipPlane));
                var moveCommand = new MoveCommand(point, UnityEngine.Random.Range(8f, 12f), transform, _spriteRenderer);
                _commands.Enqueue(moveCommand);
                break;

            default:
                var standingCommand1 = new StandingCommand(UnityEngine.Random.Range(2f, 5f));
                _commands.Enqueue(standingCommand1);
                break;
        }
        yield return new WaitForSeconds(3f);
    }
}
