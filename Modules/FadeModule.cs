using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeModule : AnimatedPanelModule
{
	public CanvasGroup canvasGroup { get; private set; }

	protected override void initialize()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	protected override void setProgressFromCurve(float curveValue)
	{
		canvasGroup.alpha = curveValue;
	}
}