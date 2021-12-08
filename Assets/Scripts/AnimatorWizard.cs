
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

public sealed class AnimatorWizard : MonoBehaviour
{
    public static readonly float secondsPerFrame = 0.01666667f;

    public static float FrameCountToSeconds(int frameCount)
    {
        return secondsPerFrame * frameCount;
    }

    public Animator animator { get; private set; }

    private Dictionary<string, UnityAction> _eventActions = new Dictionary<string, UnityAction>();

    public void Awaken()
    {
        animator = GetComponent<Animator>();
    }

    public void Rebind()
    {
        animator.Rebind();

        _eventActions = new Dictionary<string, UnityAction>();
    }

    public void SetParameterTrue(string name)
    {
        animator.SetBool(name, true);
    }

    public void SetParameterFalse(string name)
    {
        animator.SetBool(name, false);
    }

    public void SetTrigger(string name)
    {
        animator.SetTrigger(name);
    }

    public void AddEventAction(string animatorStance, UnityAction eventAction)
    {
        if (_eventActions.ContainsKey(animatorStance) == false)
        {
            _eventActions.Add(animatorStance, eventAction);
        }
    }

    public void InvokeEventAction(string animatorStance)
    {
        _eventActions[animatorStance].Invoke();
    }

    public void RemoveEventAction(string animatorStance)
    {
        _eventActions.Remove(animatorStance);
    }
}