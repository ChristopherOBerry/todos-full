using System.Collections.Generic;
using System;
using System.Data;
using todos_full.Models;
using Dapper;

namespace todos_full.Repositories
{
    public class TodosRepository
    {
        private readonly IDbConnection _db;
        public TodosRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Todo> GetAll()
        {
            return _db.Query<Todo>("SELECT * FROM todos");
        }
        public Todo CreateTodo(Todo todo)
        {
            _db.Execute("INSERT INTO todos (id, taskName, isComplete) VALUES (@Id, @TaskName, @IsComplete)", todo);
            return todo;
        }
        public bool DeleteTodo(string todoId)
        {
            int success = _db.Execute("DELETE FROM todos WHERE id = @todoId", new { todoId });
            return success > 0;
        }
    }
}