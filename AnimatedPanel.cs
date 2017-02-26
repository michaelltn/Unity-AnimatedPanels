using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class AnimatedPanel : MonoBehaviour
{
	public bool showOnEnable = false;
	public float animationTime = 0.5f;
	public bool useUnscaledDeltaTime = true;

	[SerializeField] bool getModulesInChildren = true;

	AnimatedPanelModule[] modules;

	float _displayProgress;
	public float displayProgress
	{
		get { return _displayProgress; }
		set
		{
			_displayProgress = Mathf.Clamp01(value);
			updateDisplay();
		}
	}

	protected virtual void updateDisplay()
	{
		if (modules == null || modules.Length == 0) return;

		for (int i = 0; i < modules.Length; i++)
		{
			modules[i].setProgress(displayProgress);
		}
		//uiCanvasGroup.alpha = Mathf.Clamp01(displayProgress);
	}

	public bool isAnimating
	{
		get
		{
			return _isShowing ? displayProgress < 1f : displayProgress > 0;
		}
	}

	public CanvasGroup uiCanvasGroup { get; private set; }

	virtual protected void Awake()
	{
		uiCanvasGroup = GetComponent<CanvasGroup>();
		if (uiCanvasGroup == null)
		{
			uiCanvasGroup = gameObject.AddComponent<CanvasGroup>();
		}
		uiCanvasGroup.alpha = 1f;

		modules = getModulesInChildren ? GetComponentsInChildren<AnimatedPanelModule>() : GetComponents<AnimatedPanelModule>();
		if (modules.Length == 0)Debug.LogWarning(this.name + " has no modules.", this);
	}

	virtual protected void OnEnable()
	{
		displayProgress = 0;
		isShowing = showOnEnable;
	}

	public System.Action onShow, onHide;

	bool _isShowing = false;
	public bool isShowing
	{
		get { return _isShowing; }
		private set
		{
			_isShowing = value;

            if (uiCanvasGroup != null)
            {
                uiCanvasGroup.interactable = isShowing;
                uiCanvasGroup.blocksRaycasts = isShowing;
            }
		}
	}



	public void show()
	{
		if (!isShowing)
		{
			isShowing = true;
			if (onShow != null) onShow();
		}
	}

	public void hide()
	{
		if (isShowing)
		{
			isShowing = false;
			if (onHide != null) onHide();
		}
	}

	void LateUpdate()
	{
		float deltaTime = useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;

		if (isShowing && displayProgress < 1f)
		{
			displayProgress = animationTime > 0 ? displayProgress + (deltaTime / animationTime) : 1f;
		}
		else if (!isShowing && displayProgress > 0)
		{
			displayProgress = animationTime > 0 ? displayProgress - (deltaTime / animationTime) : 0;
		}
	}
}
