using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System.Xml.Linq;
using System;

namespace Bussiness.Concrete
{
    public class EtkinlikManager : IEtkinlikService
    {
        private IEtkinlikDal _etkinlikDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectDal"></param>
        public EtkinlikManager(IEtkinlikDal projectDal)
        {
            _etkinlikDal = projectDal;
        }

        public bool CreateByResult(string baslik, string yer, DateTime zaman, bool ucretliUcretsiz, decimal ucret, string aciklama, string icon)
        {
            Etkinlik etkinlik = new Etkinlik();
            etkinlik.Baslik = baslik;
            etkinlik.Gorsel = icon;
            etkinlik.Yer = yer;
            etkinlik.Zaman = zaman;
            etkinlik.UcretliUcretsiz = ucretliUcretsiz;
            etkinlik.Ucret = ucret;
            etkinlik.Aciklama = aciklama;

            return _etkinlikDal.CreateByResult(etkinlik);
        }

        public bool UpdateByResult(int id, string baslik, string yer, DateTime zaman, bool ucretliUcretsiz, Decimal ucret, string aciklama, string icon)
        {
            Etkinlik etkinlik = new Etkinlik();
            etkinlik.Id = id;
            etkinlik.Baslik = baslik;
            etkinlik.Gorsel = icon;
            etkinlik.Yer = yer;
            etkinlik.Zaman = zaman;
            etkinlik.UcretliUcretsiz = ucretliUcretsiz;
            etkinlik.Ucret = ucret;
            etkinlik.Aciklama = aciklama;

            return _etkinlikDal.UpdateByResult(etkinlik);
        }

        public bool DeleteByResult(int id)
        {
            Etkinlik etkinlik = _etkinlikDal.GetById(id);
            return _etkinlikDal.DeleteByResult(etkinlik);
        }

        public List<Etkinlik> GetAll()
        {
            return _etkinlikDal.GetAll();
        }

        public List<Etkinlik> GetEtkinliksByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Etkinlik GetById(int id)
        {
            Etkinlik etkinlik = _etkinlikDal.GetById(id);
            return etkinlik;
        }
    }
}
