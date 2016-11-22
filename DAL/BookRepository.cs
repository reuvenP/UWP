﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DAL
{
    public class BookRepository : IRepository<Book>
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public BookRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("Mivchar_project");
        }

        public void Delete(Book entity)
        {
            var collection = _database.GetCollection<Book>("Books");
            var filter = Builders<Book>.Filter.Eq("Id", entity.Id);
            var book = collection.DeleteOne(filter);
        }

        public IEnumerable<Book> GetAll()
        {
            var collection = _database.GetCollection<Book>("Books");
            var books = collection.Find(_ => true).ToEnumerable();
            return books;
        }

        public IEnumerable<Book> GetAllByCondition(Predicate<Book> condition)
        {
            var collection = _database.GetCollection<Book>("Books");
            var query = from b in collection.AsQueryable<Book>()
                        where condition(b)
                        select b;
            return query.ToList();
            
        }

        public Book GetById(string id)
        {
            var obId = ObjectId.Parse(id);
            var collection = _database.GetCollection<Book>("Books");
            var filter = Builders<Book>.Filter.Eq("Id", obId);
            var book = collection.Find(filter).FirstOrDefault();
            return book;
        }

        public void Save(Book entity)
        {
            var collection = _database.GetCollection<Book>("Books");
            collection.InsertOne(entity);
        }

        public void Update(Book entity)
        {
            var collection = _database.GetCollection<Book>("Books");
            var filter = Builders<Book>.Filter.Eq("Id", entity.Id);
            collection.FindOneAndReplace(filter, entity);
        }
    }
}