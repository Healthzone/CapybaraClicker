using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class MoveCommand : Command
{

    private readonly Vector3 _destination;
    private readonly Transform _target;
    private readonly SpriteRenderer _spriteRenderer;
    private readonly float _speed;
    private readonly CapybaraData _capybaraData;



    public MoveCommand(Vector3 destination, float speed, Transform target, SpriteRenderer spriteRenderer)
    {
        _destination = destination;
        _target = target;
        _speed = speed;
        _spriteRenderer = spriteRenderer;
        _capybaraData = Resources.Load<CapybaraData>("CapybaraData");
    }

    public override async void Execute()
    {
        if (_target.position.x > _destination.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        var scale = InterpolateUnitScale();

        var ct = _target.GetCancellationTokenOnDestroy();

        await UniTask.WhenAll(
            _target.DOMove(_destination, _speed).WithCancellation(ct),
            _target.DOScale(scale, _speed).WithCancellation(ct)
            );

        IsFinished = true;
    }

    private Vector3 InterpolateUnitScale()
    {
        var scale = _capybaraData.LowerScaleLimt +
            ((_capybaraData.UpperScaleLimit - _capybaraData.LowerScaleLimt) /
            (_capybaraData.UpperYPosition - _capybaraData.LowerYPosition) *
            (_destination.y - _capybaraData.LowerYPosition));
        return new Vector3(scale, scale, scale);
    }

}
