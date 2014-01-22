﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OyuLib.OyuWindows.Compornent
{
    public partial class ExListBox : ListBox
    {
        #region constractor

        public ExListBox()
        {
            InitializeComponent();
        }

        public ExListBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion
    }
}
