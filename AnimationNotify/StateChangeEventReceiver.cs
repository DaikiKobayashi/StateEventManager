using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;

namespace StateEventManager
{
    public class StateChangeEventReceiver : MonoBehaviour
    {
        private Animator m_animator;
        private StateChangeObserver m_observer;
        private EventListener m_currentListener;

        private void Start()
        {
            Debug.AssertFormat(TryGetComponent(out m_animator), "please component. : Animator", this);

            m_observer = m_animator.GetBehaviour<StateChangeObserver>();
            Debug.AssertFormat(m_observer != null, "please StateMachineBehaviour. : StateChangeObserver", m_animator);

            m_observer?
                .StateChangeObservable
                .Subscribe(OnStateChange)
                .AddTo(this);
        }

        private void OnStateChange(Animator animator)
        {
            m_currentListener?
                .ListenerEvent
                .Invoke(animator);
        }

        public void ChangeEventListener(EventListener listener)
        {
            m_currentListener = listener;
        }
    }

    public class EventListener
    {
        public EventListener(UnityAction<Animator> listernerEvent)
        {
            ListenerEvent = listernerEvent;
        }

        public UnityAction<Animator> ListenerEvent { get; private set; }
    }
}
