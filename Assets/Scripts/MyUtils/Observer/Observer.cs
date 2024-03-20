using System;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;

namespace MyUtils.Observer
{
    [Serializable]
    public class Observer<T>
    {
        [SerializeField]private T value;
        [SerializeField]private UnityEvent<T> onValueChanged;

        public Observer(T value, UnityAction<T> callback = null)
        {
            this.value = value;
            onValueChanged = new UnityEvent<T>();
            if(callback != null) onValueChanged.AddListener(callback);
        }

        public T Value
        {
            get => value;
            set
            {
                if(Equals(this.value, value)) return;
                this.value = value;
                Invoke();
            }
        }

        public void Invoke()
        {
            Debug.Log($"Invoking {onValueChanged.GetPersistentEventCount()} listeners");
            onValueChanged.Invoke(value);
        }

        public void AddListener(UnityAction<T> callback)
        {
            if(callback == null) return;
            onValueChanged ??= new UnityEvent<T>();
            onValueChanged.AddListener(callback);
        }
        
        public void RemoveListener(UnityAction<T> callback)
        {
            if(callback == null) return;
            onValueChanged?.RemoveListener(callback);
        }

        public void RemoveAllListeners()
        {
            onValueChanged?.RemoveAllListeners();
        }

        public void Dispose()
        {
            RemoveAllListeners();
            onValueChanged = null;
            value = default;
        }
    }
}
