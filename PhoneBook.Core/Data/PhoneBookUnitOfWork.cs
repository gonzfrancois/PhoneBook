using System;
using PhoneBook.Core.Data.Base;
using PhoneBook.Core.Model;

namespace PhoneBook.Core.Data
{
    public sealed class PhoneBookUnitOfWork
    {
        private readonly string _jsonFormattedDataPath;
        private IGenericRepository<Card> _cardsRepository;
        private readonly Model.PhoneBook _dataContext;

        public IGenericRepository<Card> CardsRepository
            => _cardsRepository ?? (_cardsRepository = new CardsRepository(_dataContext));

        public PhoneBookUnitOfWork(string jsonFormattedDataPath)
        {
            _jsonFormattedDataPath = jsonFormattedDataPath;
            _dataContext = new Model.PhoneBook(jsonFormattedDataPath);
        }

        public void Save()
        {
            _dataContext.SaveToJson(_jsonFormattedDataPath);
        }
    }
}
