using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class FullOutfit
    {
        public int ID { get; set; }
        public List<Top> Tops { get; set; }
        public List<Bottom> Bottoms { get; set; }
        public List<Shoe> Sheos { get; set; }
        public List<Accessory> Accessories { get; set; }
        public List<OutfitPart> OutfitParts { get; set; }
        public List<string> Photos { get; set; }
    }
}