using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new() //class:referans tip olsun ,IEntity kendisi olmasın diye newledik
        where TContext:DbContext, new() //NorthwindContex:DbContext
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //  referansı veri kaynağında bul, referansı yakala Entity=giriş
                                                         //northwind contexte bu entityi bağla
                addedEntity.State = EntityState.Added; //bu bir ekleme işlemi , state=durum
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // referansı bul Entity=giriş
                deletedEntity.State = EntityState.Deleted; //bu bir silme işlemi , state=durum
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() //select* from product - tümünü getir - nullsa
                    : context.Set<TEntity>().Where(filter).ToList();
                     // producta yerleş ve oradaki tüm datayı listeye çevir

            }
        }

        public void update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateedEntity = context.Entry(entity); // referansı bul nesne ile productı eşleştir Entity=giriş
                updateedEntity.State = EntityState.Modified; //bu bir güncelleme işlemi , state=durum
                context.SaveChanges();
            }
        }

    }
}
