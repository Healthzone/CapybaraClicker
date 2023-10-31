using DG.Tweening;
using UnityEngine;

public class FlipperCommand : Command
{
    private SpriteRenderer _spriteRenderer;

    private float _flippingTime;
    public FlipperCommand(SpriteRenderer spriteRenderer, float flippingTime)
    {
        _spriteRenderer = spriteRenderer;
        _flippingTime = flippingTime;
    }

    public override void Execute()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .OnStepComplete(FlipSprite)
            .AppendInterval(_flippingTime)
            .SetLoops(4, LoopType.Incremental)
            .AppendInterval(3f)
            .OnComplete(() =>
            {
                IsFinished = true;
            });
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}

