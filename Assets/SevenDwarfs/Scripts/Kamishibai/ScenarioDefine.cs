using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.Kamishibai
{
    public enum TextType
    {
        /// <summary>地の分</summary>
        Narration,
        /// <summary>キャラセリフ</summary>
        Character,
        /// <summary>全員セリフ</summary>
        Everyone,
    }

    public enum Position
    {
        Center,
        Left,
        Right,
    }
}