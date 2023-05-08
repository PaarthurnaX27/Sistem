using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ProjeIcerikManager : IProjeIcerikService
    {
        IProjeIcerikDal _projeIcerikDal;
        public ProjeIcerikManager(IProjeIcerikDal projeIcerikDal)
        {
            _projeIcerikDal = projeIcerikDal;
        }
        public void TAdd(ProjeIcerik t)
        {
            _projeIcerikDal.Insert(t);
        }

        public void TDelete(ProjeIcerik t)
        {
            _projeIcerikDal.Delete(t);
        }

        public ProjeIcerik TGetByID(int id)
        {
            return _projeIcerikDal.Get(x => x.ProjeIcerikId == id);
        }

        public List<ProjeIcerik> TGetList()
        {
            return _projeIcerikDal.GetList();
        }

        public void TUpdate(ProjeIcerik t)
        {
            _projeIcerikDal.Update(t);
        }
    }
}

