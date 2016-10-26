using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using PhoneBook.Core.Data.Base;
using PhoneBook.Core.Model;

namespace PhoneBook.Core.Data
{
    public class CardsRepository : IGenericRepository<Card>
    {
        private readonly Model.PhoneBook _dataContext;


        public CardsRepository(Model.PhoneBook dataContext )
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Card> Get()
        {
            return _dataContext.Cards;
        }

        public IEnumerable<Card> Find(string propertyName, string discriminent)
        {
            return Find(_dataContext.Cards, propertyName, discriminent);
        }

        public Card Insert(Card entity)
        {
            _dataContext.Cards.Add(entity);
            return entity;
        }

        public void DeleteAll(Predicate<Card> predicate)
        {
            _dataContext.Cards.RemoveAll(predicate);
        }

        public void Delete(Card entityToDelete)
        {
            IEnumerable<Card> ie = _dataContext.Cards;
            for (var i = 0; i < entityToDelete.GetType().GetProperties().Length; i++)
            {
                var prop = entityToDelete.GetType().GetProperties()[i];
                ie = Find(ie, prop.Name, prop.GetValue(entityToDelete).ToString());
            }
            _dataContext.Cards.Remove(ie.First());
        }

        public IEnumerable<Card> FindInAllProperties(string where)
        {
            var ie = new List<Card>();
            for (var i = 0; i < new Card().GetType().GetProperties().Length; i++)
            {
                var prop = new Card().GetType().GetProperties()[i];
                ie.AddRange(Find(_dataContext.Cards, prop.Name, where));
            }
            return ie.Distinct();
        }

        private IEnumerable<Card> Find(IEnumerable<Card> cards, string propName, string arg)
        {
            return cards.Where(
                c => CultureInfo.CurrentUICulture.CompareInfo.IndexOf(c.GetType().GetProperty(propName).GetValue(c).ToString(), arg, CompareOptions.IgnoreCase) >= 0);
        }
    }
}
