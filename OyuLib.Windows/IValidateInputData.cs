using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OyuLib.Windows.Forms
{
    /// <summary>
    /// make Implementor Validate Proc
    /// </summary>
    interface IValidateInputData
    {
        #region Property

        #endregion

        #region Method

        bool IsValidValue();

        #endregion
    }
}
