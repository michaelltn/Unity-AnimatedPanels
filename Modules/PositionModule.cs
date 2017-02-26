using UnityEngine;
using System.Collections;

public class PositionModule : AnimatedPanelModule
{
    public Vector3 startingPosition { get; set; }
    public Vector3 endPosition { get; set; }

    protected override void initialize() { }

    protected override void setProgressFromCurve(float curveValue)
    {
        transform.position = startingPosition + (endPosition - startingPosition) * curveValue;
    }
}
