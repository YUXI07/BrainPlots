using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    /// <summary>
    ///     步骤状态
    /// </summary>
    public enum StepStatus
    {
        /// <summary>
        ///     完成
        /// </summary>
        Complete,

        /// <summary>
        ///     进行中
        /// </summary>
        UnderWay,

        /// <summary>
        ///     等待中
        /// </summary>
        Waiting
    }
}
