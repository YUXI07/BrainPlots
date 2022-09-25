using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemo
{ 
    public static class ControlCommands
    { 
        /// <summary>
        ///     上一个
        /// </summary>
        public static RoutedCommand Prev { get; } = new RoutedCommand(nameof(Prev), typeof(ControlCommands));

        /// <summary>
        ///     下一个
        /// </summary>
        public static RoutedCommand Next { get; } = new RoutedCommand(nameof(Next), typeof(ControlCommands));
    }
}
