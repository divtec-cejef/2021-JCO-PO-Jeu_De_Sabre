import socket
import json
from shutil import copyfile

def update():
		data = {}
		posX = freePieIO[0].x
		posY = freePieIO[0].y
		posZ = freePieIO[0].z

		

		dicti = {
			"x": str(posX) + "",
			"y": str(posY) + "",
			"z": str(posZ / 100) + ""
		}

		json_object = json.dumps(dicti, indent=4)
		with open("C:\Users\Katana No Tatakai\Documents\sample.json", "w") as outfile:
			outfile.write(json_object)

		try:
			copyfile('C:\Users\Katana No Tatakai\Documents\sample.json', 'C:\Users\Katana No Tatakai\Documents\data.json')
		except:
			diagnostics.debug("Erreur de lecture")
			
def update1():
		data = {}
		posX = freePieIO[1].x
		posY = freePieIO[1].y
		posZ = freePieIO[1].z		
		
		#diagnostics.watch(posX)
		#diagnostics.watch(posY)
		#diagnostics.watch(posZ)
		dicti = {
			"x": str(posX) + "",
			"y": str(posY) + "",
			"z": str(posZ / 100) + ""
		}

		json_object = json.dumps(dicti, indent=4)
		with open("C:\Users\Katana No Tatakai\Documents\sample1.json", "w") as outfile:
			outfile.write(json_object)

		try:
			copyfile('C:\Users\Katana No Tatakai\Documents\sample1.json', 'C:\Users\Katana No Tatakai\Documents\data1.json')
		except:
			diagnostics.debug("Erreur de lecture")

if starting:
	freePieIO[0].update += update
	freePieIO[1].update += update1