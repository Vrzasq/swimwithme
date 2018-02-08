using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.Models
{
    [Table("task")]
    public class TrainingTask
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public int Volume { get; set; }
        public double ETA { get; set; }
        public bool IsAmateur { get; set; }
        public bool IsSemiPro { get; set; }
        public bool IsPro { get; set; }
        public bool IsMain { get; set; }
        public bool IsPreswim { get; set; }
        public bool IsCooldown { get; set; }
        public bool IsWarmup { get; set; }
        public bool HasKickBoard { get; set; }
        public bool HasPads { get; set; }
        public bool HasFins { get; set; }
        public bool HasCups { get; set; }
        public string Lang { get; set; }
    }
}
