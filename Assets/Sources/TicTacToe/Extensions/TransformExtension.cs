using UnityEngine;

namespace TicTacToe.Extensions
{
    public static class TransformExtension
    {
        public static Transform GetRootTransform(this Transform transform)
        {
            var parentTransform = transform.parent;
            while (parentTransform.parent != null)
            {
                parentTransform = parentTransform.parent;
            }

            return parentTransform;
        }
    }
}