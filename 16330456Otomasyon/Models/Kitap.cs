//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _16330456Otomasyon.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public string KitapYazar { get; set; }
        public string KitapISBN { get; set; }
        public Nullable<int> KategoriId { get; set; }
        public string Aciklama { get; set; }
        public Nullable<System.DateTime> YayinTarihi { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public Nullable<int> KitapAdert { get; set; }
        public Nullable<int> EkleyenKullaniciId { get; set; }
        public string Resim { get; set; }
        

        public virtual Kategori Kategori { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
