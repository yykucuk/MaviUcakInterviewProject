using Entities.Models;
using System.Drawing;

namespace Bussiness.Abstract
{
    public interface IEtkinlikService
    {
        /// <summary>
        /// It gets all etkinliks
        /// </summary>
        /// <returns></returns>
        public List<Etkinlik> GetAll();

        /// <summary>
        /// It creates the new etkinlik
        /// </summary>
        /// <param name="baslik"></param>
        /// <param name="yer"></param>
        /// <param name="zaman"></param>
        /// <param name="ucretliUcretsiz"></param>
        /// <param name="ucret"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public bool CreateByResult(string baslik, string yer, DateTime zaman, bool ucretliUcretsiz, Decimal ucret, string aciklama, string icon);

        /// <summary>
        ///  It updates the new etkinlik
        /// </summary>
        /// <param name="id"></param>
        /// <param name="baslik"></param>
        /// <param name="yer"></param>
        /// <param name="zaman"></param>
        /// <param name="ucretliUcretsiz"></param>
        /// <param name="ucret"></param>
        /// <param name="aciklama"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public bool UpdateByResult(int id, string baslik, string yer, DateTime zaman, bool ucretliUcretsiz, Decimal ucret, string aciklama, string icon);

        /// <summary>
        /// It deletes the etkinlik by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteByResult(int id);

        /// <summary>
        /// It gets etkinliks with including Users by UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Etkinlik> GetEtkinliksByUserId(int id);

        /// <summary>
        /// It gets Etkinlik by etkinlik Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Etkinlik GetById(int id);

    }
}
