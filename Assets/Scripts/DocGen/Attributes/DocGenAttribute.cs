using System;
using UnityEngine;

namespace WizardsCode.Tools.DocGen
{
    [AttributeUsage(AttributeTargets.All,
                   AllowMultiple = false,
                   Inherited = true)]
    public class DocGenAttribute : PropertyAttribute
    {
        public string helpText;

        public DocGenAttribute(string description)
        {
            this.helpText = description;
        }
    }
}
