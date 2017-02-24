	var io = require('socket.io').listen(8281);
	var ioCliente = require('socket.io-client')('http://localhost:8281');
	var socketCount = 0;
	io.sockets.on('connection', function(socket){

		// Socket se ha conectado, incrementa el contador de sockets conectados
		socketCount++;
		console.log(socketCount);
		
		socket.on('disconnect', function() {
			// Decrementa el contador de sockets conecta dos y se envia un mensaje al cliente
			socketCount--;
			console.log(socketCount);
			io.sockets.emit('users_connected', socketCount);
			//io.sockets.disconnect();
			//io.sockets.close();
		});
	
		socket.on('MovilToSocket', function (data) {
		    console.log(data);
            //Se detona un evento de socket para enviar información.
			ioCliente.emit('SocketToMovil', ''); 
		});
		
		socket.on('SocketToMovil', function () {
            //Se genera una cadena de respuesta en formato json y se envia al cliente.
			var respuesta='{"Mensaje":"Enviando mensaje"}';
			io.sockets.emit('MensajeSocket', respuesta);//JSON.parse(respuesta));
		});
	
	});