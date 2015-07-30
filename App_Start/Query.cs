using moto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moto.App_Start
{
    public class Query
    {
        private motobulvarEntities db = new motobulvarEntities();
        #region markaModel
        public int Mot_MotorIddenMotModelIdDon(int Mot_MotorId)
        {
            int Sonuc = 0;
            var query = from Motors in db.mot_Motor
                        where Motors.Id == Mot_MotorId
                        select Motors;
             Sonuc = query.First().Model;
            return Sonuc;
        }
        public int Mot_ModelIddenMotMarkaIdDon(int motModelId)
        {
            int Sonuc = 0;
            var query = from motModels in db.mot_Model
                        where motModels.Id == motModelId
                        select motModels;
            Sonuc = query.First().MarkaId;
            return Sonuc;
        }
        #endregion markaModel
        
        #region Il_Ilce
        public string Mot_MotorIddenPostaKutusuIdDon(int Mot_MotorId)
        {
            string Sonuc = string.Empty;
            //var query = from Motors in db.mot_Motor
            //            where Motors.Id == Mot_MotorId
            //            select Motors;
            //Sonuc = query.First().PostaKodu;
            return Sonuc;
        }


        public string IlanIddenPostaKutusuIdDon(int IlanId)
        {
            string Sonuc = string.Empty;
            var query = from Ilans in db.Ilan
                        where Ilans.IlanId == IlanId
                        select Ilans;
            Sonuc = query.First().PostaKodu;
            return Sonuc;
        }


        public IEnumerable<sp_PKIlBaglantisi_Result> pkIlBaglantisiniDon(string PKId)
        {
            return db.sp_PKIlBaglantisi(PKId);
        }

        #endregion Il_Ilce

        #region KategoriAltKategori

        public int IlanIddenAltKategoriIdDon(int IlanId)
        {
            int Sonuc = 0;
            var query = from Ilans in db.Ilan
                        where Ilans.IlanId == IlanId
                        select Ilans;
            Sonuc = query.First().AltKategoriId;
            return Sonuc;
        }


        public int AltKategoriIddenKategoriIdDon(int AltKategoriId)
        {
            int Sonuc = 0;
            var query = from altkategoris in db.AltKategori
                        where altkategoris.Id == AltKategoriId
                        select altkategoris;
            Sonuc = query.First().KategoriId;
            return Sonuc;
        }
        #endregion KategoriAltKategori


        public int Mot_MotorIddenIlanIdDon(int Mot_MotorId)
        {
            int Sonuc = 0;
            var query = from Motors in db.mot_Motor
                        where Motors.Id == Mot_MotorId
                        select Motors;
            Sonuc = query.First().IlanId;
            return Sonuc;
        }

        public int IlanIddenMotosikletIdDon(int IlanId)
        {
            int Sonuc = 0;
            var query = from Motors in db.mot_Motor
                        where Motors.IlanId == IlanId
                        select Motors;
            Sonuc = query.First().Id;
            return Sonuc;
        }

    }
}