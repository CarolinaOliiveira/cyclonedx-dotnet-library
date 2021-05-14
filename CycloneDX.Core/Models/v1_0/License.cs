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

using System.Xml.Serialization;

namespace CycloneDX.Models.v1_0
{
    [XmlType("license")]
    public class License
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
        public bool ShouldSerializeName() { return string.IsNullOrEmpty(Id); }

        [XmlElement("text")]
        public string Text { get; set; }
        
        [XmlElement("url")]
        public string Url { get; set; }

        public License() {}

        public License(v1_1.License license)
        {
            Id = license.Id;
            Name = license.Name;
            if (license.Text != null)
                Text = license.Text.Content;
            Url = license.Url;
        }
    }
}
