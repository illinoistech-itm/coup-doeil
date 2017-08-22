## Backend service

- Connect to the server (or localhost)
- Download or clone the repository (Only the backend folder will be necesary)
- Install NodeJS and NPM on the server
- Run ```sudo npm install``` to install all dependencies
- Install MySQL server (on another server or local)
- Edit the file 'backend\CoupDOeil\app.js' with the MySQL information:

~~~
global.db = mysql.createPool({
	  connectionLimit : 10,
	  host            : 'localhost',
	  user            : 'root',
	  password        : 'coupdoeil',
	  database        : 'coupdoeil'
});
~~~

- Run MySQL server
- Run the application:

Linux:
~~~
sudo nodejs <path>/app.js
~~~

Windows: (run with admin rights)
~~~
nodejs <path>\app.js
~~~