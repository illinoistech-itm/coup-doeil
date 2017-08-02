var express = require('express');
var router = express.Router();


var drones = global.models.drones;

/* GET drones. */
router.get('/', function post(req, res, next) {
	drones.getAllDrones(function(data){
    res.send(JSON.stringify(data));
  });
});

/* POST drones. 
router.post('/', function(req, res, next) {
  var json = req.body;//JSON.parse(req.body);
  if(checkJSON(json)){
    drones.addDrone(JSON.stringify(json), 
        function(data){
          res.status(201);
          res.send(JSON.stringify(data));
        }
    );
  }
  else{
    res.status(401);
    res.send("Bad Request");
  }
	
});

/* GET drone. */
router.get('/:userId', function(req, res, next) {
  console.log(req.query);    
  drones.getDrone(req.params.userId, req.query, function(data){
    res.send(JSON.stringify(data));
  });
});

/* POST drone. */
router.post('/', function(req, res, next) {
  console.log(req.body);
  if(checkJSON(req.body)){
    var data = [req.body.NetID, req.body.Latitude, req.body.Longitude];
    drones.addData(req.params.userId, data, 
        function(data2){
          res.status(201);
          res.send(JSON.stringify(data2));
        }
    );
  }
  else{
    res.status(401);
    res.send("Bad Request");
  }
	
});

var checkJSON = function(json){
  return true; // TODO
};

module.exports = router;
