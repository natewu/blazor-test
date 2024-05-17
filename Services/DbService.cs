using Dapper;
using System;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace blazor.Services;
public class DbService : IDbService{
    private readonly IDbConnection _db;
    private readonly IConfiguration _config;
    public DbService(IConfiguration config){
        _config = config;
        string host = _config["DB_HOST"];
        string username = _config["DB_USERNAME"];
        string password = _config["DB_PASSWORD"];
        string database = _config["DB_DATABASE"];

        string connectionString = $"Host={host};Database={database};Username={username};Password={password}";
        _db = new NpgsqlConnection(connectionString);
    }

    public async Task<T> GetAsync<T>(string command, object parms){
        T result;
        result = (await _db.QueryAsync<T>(command,parms).ConfigureAwait(false)).FirstOrDefault();
        return default;
    }

    public async Task<List<T>> GetAll<T>(string command, object parms){
        List<T> result = new List<T>();
        result = (await _db.QueryAsync<T>(command, parms)).ToList();
        return result;
    }

    public async Task<T> Insert<T>(string command, object parms){
        T result;
        result = _db.Query<T>(command, parms).FirstOrDefault();
        return result;
    }

    public async Task<T> Update<T>(string command, object parms){
        T result;
        result = _db.Query(command, parms).FirstOrDefault();
        return result;
    }

    public async Task<T> Delete<T>(string command, object parms){
        T result;
        result = _db.Query<T>(command, parms).FirstOrDefault();
        return result;
    }
}