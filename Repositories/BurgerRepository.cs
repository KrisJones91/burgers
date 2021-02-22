using System.Collections.Generic;
using System.Data;
using burgers.Models;
using Dapper;


//dotnet add package dapper - in order to communicate with db
namespace burgers.Repositories
{
    public class BurgerRepository
    {
        public readonly IDbConnection _db;

        public BurgerRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Burger> GetAll()
        {
            string sql = "SELECT * FROM burgers;";
            return _db.Query<Burger>(sql);
        }

        internal Burger GetById(int id)
        {
            string sql = "SELECT * FROM burgers WHERE id = @id;";
            return _db.QueryFirstOrDefault<Burger>(sql, new { id });
        }

        internal Burger Create(Burger newBurger)
        {
            string sql = @"
                INSERT INTO burgers
                (name, description, price)
                VALUES
                (@Name, @Description, @Price);
                SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBurger);
            newBurger.Id = id;
            return newBurger;
        }

        internal Burger Edit(Burger original)
        {
            string sql = @"
                UPDATE burgers
                SET
                    description = @Description,
                    price = @Price
                WHERE id = @Id;
                SELECT * FROM burgers WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Burger>(sql, original);
        }

        internal void Delete(Burger burger)
        {
            string sql = "DELETE FROM burgers WHERE id = @Id";
            _db.Execute(sql, burger);
        }





    }
}