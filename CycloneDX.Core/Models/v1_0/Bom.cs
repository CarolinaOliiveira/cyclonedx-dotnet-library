// This file is part of the CycloneDX Tool for .NET
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Copyright (c) Steve Springett. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace CycloneDX.Models.v1_0
{
    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    [XmlRoot("bom", Namespace="http://cyclonedx.org/schema/bom/1.0", IsNullable=false)]
    public class Bom
    {
        [XmlAttribute("version")]
        public int Version { get; set; } = 1;

        [XmlArray("components")]
        public List<Component> Components { get; set; }

        public Bom() {}
        
        public Bom(v1_1.Bom bom)
        {
            Version = bom.Version;
            if (bom.Components != null)
            {
                Components = new List<Component>();
                foreach (var component in bom.Components)
                {
                    var convertedComponent = new Component(component);
                    if (Enum.IsDefined(typeof(Component.ComponentType), convertedComponent.Type))
                    {
                        Components.Add(convertedComponent);
                    }
                }
            }
        }
    }
}