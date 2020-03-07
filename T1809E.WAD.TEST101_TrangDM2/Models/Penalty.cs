using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E.WAD.TEST101_TrangDM2.Models
{
    public class Penalty
    {
      [Key] public int Id { get; set; }
      public string StudentId { get; set; }
      public PenaltyMethod Method { get; set; }
      public int Amount { get; set; }
      public DateTime DateTime { get; set; }
      public enum PenaltyMethod
      {
        PushUp = 0,
        Cash = 1
      }
    }
}