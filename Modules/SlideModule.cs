using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideModule : AnimatedPanelModule
{
	public CanvasGroup canvasGroup { get; private set; }

	RectTransform rectTransform;

	public Vector2 hiddenOffset;
	Vector2 defaultPosition, hiddenPosition;

	protected override void initialize()
	{
		rectTransform = GetComponent<RectTransform>();

		defaultPosition = rectTransform.anchoredPosition;
		hiddenPosition = defaultPosition + hiddenOffset;
	}

	protected override void setProgressFromCurve(float curveValue)
	{
		rectTransform.anchoredPosition = hiddenPosition + (defaultPosition - hiddenPosition) * curveValue;
	}
}