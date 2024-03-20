using System.Collections;
using UnityEngine;

namespace Game
{
    public class PowerUp : MonoBehaviour
    {
        #region VARIABLES
        public bool hasActiveTime, isActive;
        [SerializeField]
        protected float activeTime;
        #endregion

        #region METHODS

    
        public virtual void Activate() 
        {
            if (hasActiveTime)
            {
                ResetCountDown();
            }

            isActive = true;

            //Logic
        }
        public virtual void Deactivate() 
        {
            isActive = false;

            //Logic
        }
        private IEnumerator CountDown()
        {
            yield return new WaitForSeconds(activeTime);
            Deactivate();
        }
        protected virtual void ResetCountDown()
        {
            StartCoroutine(CountDown());
        }

   
        #endregion
    }
}
