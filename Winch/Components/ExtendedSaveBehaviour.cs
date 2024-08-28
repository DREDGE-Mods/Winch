using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Data;
using Winch.Util;

namespace Winch.Components
{
    /// <summary>
    /// <inheritdoc cref="ExtendedSaveData.Participant"/>
    /// <see cref="MonoBehaviour"/> version of <see cref="ExtendedSaveData.Participant"/>.
    /// </summary>
    public abstract class ExtendedSaveBehaviour : MonoBehaviour, ExtendedSaveData.Participant
    {
        /// <inheritdoc cref="ExtendedSaveData.Participant.Key"/>
        public abstract string Key { get; }
        /// <inheritdoc cref="ExtendedSaveData.Participant.Load"/>
        public abstract void Load(JToken token);
        /// <inheritdoc cref="ExtendedSaveData.Participant.Save"/>
        public abstract object Save();

        /// <summary>
        /// Registers this participant
        /// </summary>
        public virtual void Awake()
        {
            SaveUtil.RegisterDataParticipant(this);
        }

        /// <summary>
        /// Unregisters this participant
        /// </summary>
        public virtual void OnDestroy()
        {
            SaveUtil.UnregisterDataParticipant(this);
        }
    }
}
