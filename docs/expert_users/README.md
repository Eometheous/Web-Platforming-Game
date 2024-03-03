Building product instructions (JAL)

Cloning GitHub project to computer
	(Option 1) Using GitHub Desktop
		Download the GitHub Desktop app and log in
		Clone our project by selecting clone project by URL and paste in this URL
			https://github.com/Eometheous/Web-Platforming-Game.git
		Select a folder you want the project to be in and wait for the cloning to complete
	(Option 2) Using command line
		Open cmd
		cd into the desired folder
		git clone https://github.com/Eometheous/Web-Platforming-Game.git

Building website
	Download VS Code and open the project inside the previously selected folder
	cd into dev/JALWebsite
	Instal things like Flask and Python if you don’t have it on your machine
	cd into /server and run the server by typing 
		python app.py
	cd into /client and run
		Install node.js
		npm install (install npm on machine)
		npm run build (to check and make sure there’s no error with the svelte code)
		npm run dev (to see the website)
			Once this is run it will give you a local host link
			Paste and enter that link into the internet browser

Building Unity Game (not connected to the website yet)
	(Option 1) Building in Unity
		Have Unity installed
		Open Unity and open the game by navigating and selecting the dev/Unity folder
		Inside of Unity
			Open assets/scenes/Basic Level
			Press the play button up the top of the window
			Current scene: you should see a basic platformer level with two characters 
			Move player1 using WASD and player2 using arrow keys
	(Option 2) Just playing on Itch.io
		This option is for if you just want to play the game quickly (works on most browsers)
		Go to this link:
			https://byuntaeyeon02.itch.io/jal
			Password is 123123
