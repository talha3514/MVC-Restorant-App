//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restorant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class yemekler
    {
        public int yemek_id { get; set; }
        public string yemek_adi { get; set; }
        public int yemek_fiyati { get; set; }
        public string yemek_tarifi { get; set; }
        public int katagori_id { get; set; }
        public byte[] yemek_resim { get; set; }
    
        public virtual kategori kategori { get; set; }
    }
}
