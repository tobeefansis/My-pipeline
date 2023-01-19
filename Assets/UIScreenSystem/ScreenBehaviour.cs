using UnityEngine;
using UnityEngine.Events;

namespace UIScreenSystem
{
    public class ScreenBehaviour : MonoBehaviour
    {
        [SerializeField] private UnityEvent onHide;
        [SerializeField] private UnityEvent onShow;
        [SerializeField] private UnityEvent onClose;
        [SerializeField] private UnityEvent onOpen;
        
        public virtual void Hide()
        {
            Debug.Log($"{name} Hide");
            onHide.Invoke();
        }
        public virtual void Show()
        {
            Debug.Log($"{name} Show");
            onShow.Invoke();

        }
        public virtual void Close()
        {
            Debug.Log($"{name} Close");
            onClose.Invoke();

        }
        public virtual void Open()
        {
            Debug.Log($"{name} Open");
            onOpen.Invoke();

        } 
    }
}
