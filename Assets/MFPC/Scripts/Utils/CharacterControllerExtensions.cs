using UnityEngine;

namespace MFPC.Utils
{
    public static class CharacterControllerExtensions
    {
        public static void Transfer(this CharacterController @this, Vector3 target)
        {
            @this.gameObject.transform.position = target;
            Physics.SyncTransforms();
        }
    }
}