using Boo.Lang;
using UnityEngine;

namespace Utility
{
    public static class StringExtensions
    {
        
        // 拡張メソッド
        public static string[] 文字数分割(this string str, int count) {
            var list = new List<string>();
            int length = Mathf.CeilToInt((float)str.Length / count);
      
            for(int i = 0; i < length; i++) {
                int start = count * i;
                if(str.Length <= start) {
                    break;
                }
                if(str.Length < start + count) {
                    list.Add(str.Substring(start));
                } else {
                    list.Add(str.Substring(start, count));
                }
            }
      
            return list.ToArray();
        }
        
    }
}