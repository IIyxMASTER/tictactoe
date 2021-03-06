using UnityEngine;

namespace TicTacToe.Extensions
{
    public static class RectTransformExtensions
    {
        public static RectTransform Left( this RectTransform rt, float x )
        {
            rt.offsetMin = new Vector2( x, rt.offsetMin.y );
            return rt;
        }
 
        public static RectTransform Right( this RectTransform rt, float x )
        {
            rt.offsetMax = new Vector2( -x, rt.offsetMax.y );
            return rt;
        }
 
        public static RectTransform Bottom( this RectTransform rt, float y )
        {
            rt.offsetMin = new Vector2( rt.offsetMin.x, y );
            return rt;
        }
 
        public static RectTransform Top( this RectTransform rt, float y )
        {
            rt.offsetMax = new Vector2( rt.offsetMax.x, -y );
            return rt;
        }
        public static void SetRect(this RectTransform trs, float left, float top, float right, float bottom)
        {
            trs.offsetMin = new Vector2(left, bottom);
            trs.offsetMax = new Vector2(-right, -top);
        }
    }
}