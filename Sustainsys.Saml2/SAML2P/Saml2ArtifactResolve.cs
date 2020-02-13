﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sustainsys.Saml2.Saml2P
{
    /// <summary>
    /// Artifact resolution request, corresponds to section 3.5.1 in SAML
    /// core specification.
    /// </summary>
    public class Saml2ArtifactResolve : Saml2RequestBase
    {
        /// <summary>
        /// Artifact to resolve.
        /// </summary>
        public string Artifact { get; set; }

        /// <summary>
        /// The SAML2 request name
        /// </summary>
        [ExcludeFromCodeCoverage]
        protected override string LocalName
        {
            get
            {
                return "ArtifactResolve";
            }
        }

        /// <summary>
        /// Serializes the message into wellformed Xml.
        /// </summary>
        /// <returns>string containing the Xml data.</returns>
        public override string ToXml()
        {
            var xElement = new XElement(
                Saml2Namespaces.Saml2P + "ArtifactResolve",
                base.ToXNodes(),
                new XElement(Saml2Namespaces.Saml2P + "Artifact", Artifact));

            XmlCreated(xElement);

            return xElement.ToString();
        }

        private Action<XElement> Saml2ArtifactResolve_XmlCreated;
    }
}
