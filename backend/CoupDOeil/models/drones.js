var db = global.db;
var model = {};

model.getAllDrones = function(callback){
  db.getConnection(function(err, connection) {
    if (err) throw error;
    
    connection.query('SELECT droneid, concat(\'http://13.59.155.171/drone/\', droneid) as url FROM drone_data GROUP BY droneid', function (error, results, fields) {
    // And done with the connection.
    connection.release();

    // Handle error after the release.
    if (error) throw error;
    
    callback(results);

    });
  });
};

model.getDrone = function(id, queries, callback){
  db.getConnection(function(err, connection) {
    if (err) throw error;
    var from = queries.from || 0;
    var to = queries.to || 14986824070000;
    var limit = Number(queries.limit) || 50;
    connection.query('SELECT dd.*, unix_timestamp(dd.date) as timestamp FROM drone_data dd WHERE droneid = ? AND UNIX_timestamp(date) >= ? AND UNIX_timestamp(date) <= ? ORDER BY date DESC LIMIT ' + limit, [id, from, to], function (error, results, fields) {
    // And done with the connection.
    connection.release();

    // Handle error after the release.
    if (error) throw error;
    
    callback(results);

    });
  });
};

model.addDrone = function(data, callback){
  db.getConnection(function(err, connection) {
    if (err) throw error;
    
    connection.query('INSERT INTO drone (name, model) VALUES (?, ?)', [data.name, data.model], function (error, results, fields) {
    // And done with the connection.
    connection.release();

    // Handle error after the release.
    if (error) throw error;
    
    callback(data);

    });
  });
};

model.addData = function(id, data, callback){
  db.getConnection(function(err, connection) {
    if (err) throw error;
    
    connection.query('INSERT INTO drone_data (droneid, latitude, longitude, date) VALUES (?, ?, ?, now())', [data[0], data[1], data[2]], function (error, results, fields) {
    // And done with the connection.
    connection.release();

    // Handle error after the release.
    if (error) throw error;
    
    callback(data);

    });
  });
};

module.exports = model;
