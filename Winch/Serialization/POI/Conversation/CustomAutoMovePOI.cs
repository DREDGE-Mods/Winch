using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Serialization.POI.Conversation;

public class CustomAutoMovePOI : CustomConversationPOI
{
    /// <summary>
    /// Position to move the player's boat to, relative to this point of interest.
    /// </summary>
    [SerializeField]
    public Vector3 autoMovePosition = Vector3.zero;

    /// <summary>
    /// Whether to use <see cref="autoMoveRotation"/>
    /// </summary>
    [SerializeField]
    public bool includeRotation = false;

    /// <summary>
    /// Rotation to move the player's boat to, relative to this point of interest.
    /// </summary>
    [SerializeField]
    public Vector3 autoMoveRotation = Vector3.zero;

    /// <summary>
    /// Whether to unlock player movement after the dialogue ends
    /// </summary>
    [SerializeField]
    public bool unlockPlayerMovementAfterConversationCompleted = true;
}
