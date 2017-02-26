using UnityEngine;
using System.Collections;

public abstract class AnimatedPanelModule : MonoBehaviour
{
	public AnimationCurve animationCurve;

	public void setProgress(float progress)
	{
		if (initialized == false)
		{
			initialize();
			initialized = true;
		}

		setProgressFromCurve(animationCurve.Evaluate(progress));
	}

	public bool initialized { get; private set; }

	void Awake()
	{
		if (initialized == false)
		{
			initialize();
			initialized = true;
		}
	}

	abstract protected void initialize();
	abstract protected void setProgressFromCurve(float curveValue);


}
