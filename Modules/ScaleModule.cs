using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleModule : AnimatedPanelModule
{
	public CanvasGroup canvasGroup { get; private set; }

	RectTransform rectTransform;

	public Vector3 hiddenLocalScale;
	Vector3 defaultLocalScale;

	protected override void initialize()
	{
		rectTransform = GetComponent<RectTransform>();

		defaultLocalScale = rectTransform.localScale;
	}

	protected override void setProgressFromCurve(float curveValue)
	{
		rectTransform.localScale = hiddenLocalScale + (defaultLocalScale - hiddenLocalScale) * curveValue;
	}
}