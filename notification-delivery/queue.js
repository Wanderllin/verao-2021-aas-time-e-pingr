// this persistence is only for test
var receivedMessages = [
	{
		"event": "NewFollower",
		"originUserId": "1",
		"destinationUserId": "2",
	},
	{
		"event": "NewFollower",
		"originUserId": "1",
		"destinationUserId": "3",
	},
	{
		"event": "NewFollower",
		"originUserId": "2",
		"destinationUserId": "1",
	},
];
// connect with RabbitMQ server
function connect(){
  return require('amqplib').connect("pingr:pingr@localhost:15672/vhost")
                           .then(conn => conn.createChannel());
} 
// create a queue with an especific name
function createQueue(channel, queueName){
  return new Promise((resolve, reject) => {
    try{
      channel.assertQueue(queueName, { durable: true });
      resolve(channel);
    }
    catch(err){ reject(err) }
  });
}
// send a message to a queue
function sendToQueue(queueName, jsonMessage){
  connect()
    .then(channel => createQueue(channel, queueName))
    .then(channel => channel.sendToQueue(queueName, Buffer.from(JSON.stringify(jsonMessage))))
    .catch(err => console.log(err))
}
// consume a queue
function consume(queueName, callback){
  connect()
    .then(channel => createQueue(channel, queueName))
    .then(channel => channel.consume(queueName, callback, { noAck: true }))
    .catch(err => console.log(err));
}
// keep the program consuming a queue
function keepConsuming(queueName) {
	consume(queueName, message => {
		// process the message
		console.log("Message Received: " + message.content.toString());
		receivedMessages.push(message.content);
		keepConsuming(queueName);
	});
}

// --------------- public methods ------------------- //

exports.getNotifications = function(userId) {
	var lstNotifications = [];
	for (var i = 0; i < receivedMessages.length; i++)
		if (receivedMessages[i].destinationUserId == userId)
			lstNotifications.push(receivedMessages[i]);
	return lstNotifications;
}

exports.readQueue = function() {
	keepConsuming("profile-interactions");
}