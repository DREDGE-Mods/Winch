using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Winch.Core;

namespace Winch.Components
{
    public abstract class SceneDependentBehaviour : MonoBehaviour
    {
        public virtual void Awake()
        {
            SceneManager.sceneLoaded += TriggerSceneLoaded;
            SceneManager.sceneUnloaded += TriggerSceneUnloaded;
            SceneManager.activeSceneChanged += TriggerActiveSceneChanged;
        }

        public virtual void OnDestroy()
        {
            SceneManager.sceneLoaded -= TriggerSceneLoaded;
            SceneManager.sceneUnloaded -= TriggerSceneUnloaded;
            SceneManager.activeSceneChanged -= TriggerActiveSceneChanged;
        }

        private void TriggerSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            try
            {
                OnSceneLoaded(scene, mode);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }
        private void TriggerSceneUnloaded(Scene scene)
        {
            try
            {
                OnSceneUnloaded(scene);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }
        private void TriggerActiveSceneChanged(Scene current, Scene next)
        {
            try
            {
                OnActiveSceneChanged(current, next);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }

        public virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {

        }
        public virtual void OnSceneUnloaded(Scene scene)
        {

        }
        public virtual void OnActiveSceneChanged(Scene current, Scene next)
        {

        }
    }
}
