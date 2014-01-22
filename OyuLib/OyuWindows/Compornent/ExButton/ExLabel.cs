using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace OyuLib.OyuWindows.Interface.ExButton
{
    public partial class ExLabel : Label
    {
        public ExLabel()
        {
            InitializeComponent();
        }

        public ExLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Clear()
        {
            this.Text = string.Empty;
        }
    }
}
