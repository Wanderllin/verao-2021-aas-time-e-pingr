// Config

var httpPort = 3000;
var allowedOrigins = ["chrome-extension:", "://localhost:"]; // for CORS policy. If this array is empty the program don´t use this policy.

// ---------- WebServer ---------- //

var express = require('express');
var cors = require('cors');
var bodyParser = require('body-parser');
var queue = require('./queue.js');

var app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
if (allowedOrigins.length > 0)
    app.use(cors({
        origin: function(origin, callback) {
            if (!origin) return callback(null, true);
            for (var i = 0; i < allowedOrigins.length; i++)
                if (origin.indexOf(allowedOrigins[i]) > -1)
                    return callback(null, true);
            return callback(new Error("The CORS policy do not allow the origin [" + origin + "]."), false);
        }
    }));

var router = express.Router();

router.post('/getNotifications', (req, res) => {
    res.json(queue.getNotifications(req.body.userId));
});

app.use('/', router);
app.listen(httpPort);
console.log("Web server online on port " + httpPort.toString());

console.log("\n Reading queue...");
queue.readQueue();
