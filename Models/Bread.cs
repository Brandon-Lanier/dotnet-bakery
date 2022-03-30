using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    // An enumeration, a list
    public enum BreadType
    {
        Sourdough, // 0
        Pumpernickel, // 1
        French,  //2
        Brioche, //3
        Artisan, //4
        Wheat // 5
    }
    public class Bread 
    {
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}

        // bread type from the above enum
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type {get; set;}
        // how many
        public int count {get; set;}

        // relate this bread to the baker in the DB
        [ForeignKey("Bakers")]
        public int bakedById {get; set;}

        public Baker bakedBy {get; set;}

    }
}
