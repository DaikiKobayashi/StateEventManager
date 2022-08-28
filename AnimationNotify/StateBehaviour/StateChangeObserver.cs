using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace StateEventManager
{
    public class StateChangeObserver : StateMachineBehaviour
    {
        private Subject<Animator> stateChangeSubject;
        public IObservable<Animator> StateChangeObservable => stateChangeSubject;

        /// <summary>
        /// �X�e�[�g�J�n�C�x���g
        /// </summary>
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            stateChangeSubject
                .OnNext(animator);
        }
    }
}