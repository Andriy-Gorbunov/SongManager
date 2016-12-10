﻿using RadioEtherMonitor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RadioEtherMonitor
{
    public static class CustomCommands
    {
        public static readonly ICommand LoadRadiostationsList = new LoadRadiostationsCommand();
    }
}