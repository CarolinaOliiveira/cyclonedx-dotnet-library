﻿// This file is part of the CycloneDX Tool for .NET
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

using System.Collections.Generic;
using System.Xml.Serialization;

namespace CycloneDX.Models.v1_3
{
    public class Issue
    {
        public enum IssueClassification
        {
            [XmlEnum(Name = "defect")]
            Defect,
            [XmlEnum(Name = "enhancement")]
            Enhancement,
            [XmlEnum(Name = "security")]
            Security
        }

        [XmlAttribute("type")]
        public IssueClassification Type { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("source")]
        public Source Source { get; set; }

        [XmlArray("references")]
        [XmlArrayItem("url")]
        public List<string> References { get; set; }

        public Issue() {}

        public Issue(v1_2.Issue issue)
        {
            Type = (IssueClassification)issue.Type;
            Id = issue.Id;
            Name = issue.Name;
            Description = issue.Description;
            if (issue.Source != null)
                Source = new Source(issue.Source);
            References = issue.References;
        }
    }
}
