using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{

    private readonly Vector3 _destination;
    private readonly Transform _target;
    private readonly SpriteRenderer _spriteRenderer;
    private readonly float _speed;

    public MoveCommand(Vector3 destination, float speed, Transform target, SpriteRenderer spriteRenderer)
    {
        _destination = destination;
        _target = target;
        _speed = speed;
        _spriteRenderer = spriteRenderer;
    }

    public override void Execute()
    {
        if (_target.position.x > _destination.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _target.DOMove(_destination, _speed).OnComplete(() =>
        {
            IsFinished = true;
        });
    }
}
