using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour , IListener
{
    [SerializeField]
    [Tooltip("the event that list listener is waiting for")]
    private Event _event;

    [SerializeField]
    [Tooltip("The action to pefrom when the event is raised")]
    private UnityEvent _actions = new UnityEvent();

    [SerializeField]
    [Tooltip("the game object that will raise the event." +
        " Actions are only performed when this game object raises the event")]
    private GameObject _intendedSender;

    /// <summary>
    /// Initialize all deafault values
    /// </summary>
    /// <param name="listenerEvent">THe event this object should listen for</param>
    /// <param name="sender">The game object that will raise the event</param>
    public void Init(Event listenerEvent, GameObject sender = null)
    {
        _event = listenerEvent;
        _event.AddListener(this);
        _intendedSender = sender;
        _actions = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!_event)
            _event = ScriptableObject.CreateInstance<Event>();

        _event.AddListener(this);
    }

    public void AddAction(UnityAction action)
    {
        if (action == null)
            _actions = new UnityEvent();

        _actions.AddListener(action);
    }

    public void ClearAction()
    {
        _actions.RemoveAllListeners();
    }

    public void Invoke(GameObject sender = null)
    {
        if (_intendedSender == sender || _intendedSender == null)
            _actions?.Invoke();

    }
}
