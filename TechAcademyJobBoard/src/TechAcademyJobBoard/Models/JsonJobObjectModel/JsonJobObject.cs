﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TechAcademyJobBoard.Models.JsonJobObjectModel
{
    public class JsonJobObject
    {
        public int ID { get; set; }

        [JsonProperty("JsonJob")]
        public JsonJob JsonJob { get; set; }
    }

    public class JsonJob
    {
        public int ID { get; set; }

        [JsonProperty(PropertyName = "ApplicationLink")]
        public string ApplicationLink { get; set; }

        [JsonProperty(PropertyName = "Company")]
        public string Company { get; set; }

        [JsonProperty(PropertyName = "DatePosted")]
        public string DatePosted { get; set; }

        [JsonProperty(PropertyName = "Experience")]
        public string Experience { get; set; }

        [JsonProperty(PropertyName = "Hours")]
        public string Hours { get; set; }

        [JsonProperty(PropertyName = "JobID")]
        public string JobID { get; set; }

        [JsonProperty(PropertyName = "JobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty(PropertyName = "LanguagesUsed")]
        public string LanguagesUsed { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "Salary")]
        public string Salary { get; set; }
    }
}

