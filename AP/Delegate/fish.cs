using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UsefulToolAP.Delegate
{
    /// <summary>
    /// 漁獲
    /// </summary>
    public class Fish
    {
        public int Age { get; set; }
        public FishType Type { get; set; }
        public bool Scales { get; set; }

        public bool IsAlive { get; set; }
                
    }
    /// <summary>
    /// 漁種
    /// </summary>
    public enum FishType
    {
        /// <summary>
        /// 魚
        /// </summary>
        Fish = 0,
        /// <summary>
        /// 魷魚
        /// </summary>
        Squid = 1,
        /// <summary>
        /// 垃圾
        /// </summary>
        Garbage =2
    }
}
